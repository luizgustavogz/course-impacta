using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMercadoFinal.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ProjetoMercadoFinal.Dto;

namespace ProjetoMercadoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendaController : ControllerBase
    {
        private readonly ProjetoMercadoFinalDBContext _context;

        public VendaController(ProjetoMercadoFinalDBContext context)
        {
            _context = context;
        }

        // GET: api/Venda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVenda()
        {
            var isAdmin = User.IsInRole("ADMIN");

            Usuario logged = null;
            if (!isAdmin)
            {
                var idUsuarioLogged = User.Claims.Where(e => e.Type == ClaimTypes.Sid).Select(e => e.Value).FirstOrDefault();

                if (!string.IsNullOrEmpty(idUsuarioLogged))
                {
                    logged = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == int.Parse(idUsuarioLogged));
                }

                if (logged == null)
                {
                    return BadRequest("Usuario nao encontrado");
                }
            }

            var projetoProjetoMercadoFinalContext = _context.Venda
                    .Include(v => v.Usuario)
                    .Include(v => v.Itens)
                    .ThenInclude(i => i.Produto)
                    .Where(v => isAdmin == true || (v.IdUsuario == logged.Id));
            var result = await projetoProjetoMercadoFinalContext.ToListAsync();
            return Ok(result);
        }

        // GET: api/Venda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var isAdmin = User.IsInRole("ADMIN");

            Usuario logged = null;
            if (!isAdmin)
            {
                var idUsuarioLogged = User.Claims.Where(e => e.Type == ClaimTypes.Sid).Select(e => e.Value).FirstOrDefault();

                if (!string.IsNullOrEmpty(idUsuarioLogged))
                {
                    logged = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == int.Parse(idUsuarioLogged));
                }

                if (logged == null)
                {
                    return BadRequest("Usuario nao encontrado");
                }
            }

            var venda = await _context.Venda.FirstOrDefaultAsync(v => v.Id == id && (isAdmin || v.IdUsuario == logged.Id));

            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }

        // POST: api/Venda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venda>> PostVenda(VendaDto[] items)
        {
            var idUsuarioLogged = User.Claims.Where(e => e.Type == ClaimTypes.Sid).Select(e => e.Value).FirstOrDefault();
            var idUsuario = int.Parse(idUsuarioLogged);

            var logged = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == int.Parse(idUsuarioLogged));

            if (logged == null)
            {
                return BadRequest("Usuario nao encontrado");
            }

            var venda = new Venda() { IdUsuario = idUsuario, Total = 0 };

            _context.Venda.Add(venda);
            await _context.SaveChangesAsync();

            VendaItem item;
            decimal total = 0;
            foreach (var i in items)
            {
                var produto = _context.Produto.Find(i.IdProduto);

                if (produto == null)
                {
                    continue;
                }

                item = new VendaItem()
                {
                    IdProduto = i.IdProduto,
                    IdVenda = venda.Id,
                    Quantidade = i.Quantidade
                };

                _context.VendaItem.Add(item);
                await _context.SaveChangesAsync();

                total += produto.Valor * i.Quantidade;
            }

            venda.Total = total;
            await _context.SaveChangesAsync();

            return Ok(_context.Venda
                    .Include(v => v.Usuario)
                    .Include(v => v.Itens)
                    .ThenInclude(i => i.Produto)
                    .Where(v => v.Id == venda.Id));
        }
    }
}
