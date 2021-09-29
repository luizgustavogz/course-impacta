using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoMVC.Data;
using MercadoMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ProjetoMercadoMVC.Controllers
{
    [Controller]
    [Route("/")]
    public class VendasController : Controller
    {
        private readonly MercadoMVCContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public VendasController(MercadoMVCContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var isAdmin = User.IsInRole("ADMIN");
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);

                var projetoMercadoMVCContext = _context.Venda
                        .Include(v => v.Usuario)
                        .Include(v => v.Itens)
                        .ThenInclude(i => i.Produto)
                        .Where(v => isAdmin == true || (v.IdUsuario == user.Id));
                return View(await projetoMercadoMVCContext.ToListAsync());
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        // GET: Vendas/Details/5
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var venda = await getVendaAtualizada(id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        [Route("Create")]
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            //ViewData["IdUsuario"] = new SelectList(_context.Usuario, "Id", "Nome");
            ViewData["Produtos"] = new SelectList(_context.Produto, "Id", "Nome");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create(int idProduto, int quantidade, int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            if (idProduto <= 0)
            {
                ViewData["ErrorProduto"] = "Produto nao informado";
            }

            var produto = await _context.Produto.FirstOrDefaultAsync(p => p.Id == idProduto);
            if (produto == null)
            {
                return NotFound();
            }

            if (quantidade <= 0)
            {
                ViewData["ErrorQtd"] = "Quantidade nao informada";
            }

            Venda venda = null;
            if (id > 0)
            {
                venda = await getVendaAtualizada(id);
            }

            if (idProduto > 0 && quantidade > 0)
            {
                if (id == null || id == 0)
                {
                    var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                    venda = new Venda()
                    {
                        IdUsuario = user.Id,
                        Total = produto.Valor * quantidade
                    };

                    _context.Add(venda);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    venda.Total += produto.Valor * quantidade;
                    await _context.SaveChangesAsync();
                }

                var item = new VendaItem()
                {
                    IdProduto = produto.Id,
                    IdVenda = venda.Id,
                    Quantidade = quantidade
                };

                _context.VendaItem.Add(item);
                await _context.SaveChangesAsync();
            }

            ViewData["Produtos"] = new SelectList(_context.Produto, "Id", "Nome");
            Venda vendaAtualizada = null;

            if (venda != null)
            {
                vendaAtualizada = await getVendaAtualizada(venda.Id);
            }

            return View(vendaAtualizada);
        }
        private async Task<Venda> getVendaAtualizada(int? id)
        {
            var isAdmin = User.IsInRole("ADMIN");
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            var venda = await _context.Venda
                .Include(v => v.Usuario)
                .Include(v => v.Itens).ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(m => m.Id == id && (isAdmin == true || (m.IdUsuario == user.Id)));

            return venda;
        }
    }
}
