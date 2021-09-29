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

namespace MercadoMVC.Controllers
{
    [Controller]
    [Route("[controller]")]
    //[Authorize]
    public class ProdutosController : Controller
    {
        private readonly MercadoMVCContext _context;

        public ProdutosController(MercadoMVCContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("ADMIN"))
            {
                return Redirect("/Identity/Account/Login");
            }

            return View(await _context.Produto.ToListAsync());
        }

        // GET: Produtos/Details/5
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {

            if (!User.Identity.IsAuthenticated || !User.IsInRole("ADMIN"))
            {
                return Redirect("/Identity/Account/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        [Route("Create")]
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("ADMIN"))
            {
                return Redirect("/Identity/Account/Login");
            }

            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create(int id, string nome, DateTime validade, string valor)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("ADMIN"))
            {
                return Redirect("/Identity/Account/Login");
            }

            var valorConvertido = valor.Replace(".", ",");
            var produto = new Produto()
            {
                Id = id,
                Nome = nome,
                Validade = validade,
                Valor = decimal.Parse(valorConvertido)
            };

            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("ADMIN"))
            {
                return Redirect("/Identity/Account/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            produto.ValorAExibir = produto.Valor.ToString().Replace(".", ",");

            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, string nome, DateTime validade, string valorAExibir)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("ADMIN"))
            {
                return Redirect("/Identity/Account/Login");
            }

            var valorConvertido = valorAExibir.Replace(".", ",");
            var produto = new Produto()
            {
                Id = id,
                Nome = nome,
                Validade = validade,
                Valor = decimal.Parse(valorConvertido)
            };

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }
        // GET: Produtos/Delete/5
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("ADMIN"))
            {
                return Redirect("/Identity/Account/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("ADMIN"))
            {
                return Redirect("/Identity/Account/Login");
            }

            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
