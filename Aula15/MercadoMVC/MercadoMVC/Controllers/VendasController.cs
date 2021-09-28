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

namespace ProjetoMercadoMVC.Controllers
{
    [Controller]
    [Route("/")]
    //[Authorize]
    public class VendasController : Controller
    {
        private readonly MercadoMVCContext _context;

        public VendasController(MercadoMVCContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var shortName = User.Identity.Name;
            var projetoMercadoMVCContext = _context.Venda.Include(v => v.Usuario).Include(v => v.Itens).ThenInclude(i => i.Produto);
            return View(await projetoMercadoMVCContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
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
        public async Task<IActionResult> Create(int idUsuario, int idProduto, int quantidade, int? id)
        {
            if (idUsuario <= 0)
            {
                ViewData["ErrorUsuario"] = "Usuario nao informado";
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

            if (idUsuario > 0 && idProduto > 0 && quantidade > 0)
            {
                if (id == null || id == 0)
                {
                    venda = new Venda()
                    {
                        //IdUsuario = idUsuario,
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
                //ViewData["IdUsuario"] = new SelectList(_context.Usuario, "Id", "Nome", venda.IdUsuario);
                vendaAtualizada = await getVendaAtualizada(venda.Id);
            }
            else
            {
                //ViewData["IdUsuario"] = new SelectList(_context.Usuario, "Id", "Nome");
            }

            return View(vendaAtualizada);
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.Id == id);
        }

        private async Task<Venda> getVendaAtualizada(int? id)
        {
            var venda = await _context.Venda
                .Include(v => v.Usuario)
                .Include(v => v.Itens).ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);

            return venda;
        }
    }
}
