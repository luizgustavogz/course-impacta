using Microsoft.EntityFrameworkCore;
using ProdutosEF.Dtos;
using ProdutosEF.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEF.Repositories.Impl
{
    class VendaRepositoryImpl : VendaRepository
    {
        private ProdutosEFDBContext _context;

        public VendaRepositoryImpl(ProdutosEFDBContext context)
        {
            _context = context;
        }

        public void Salvar(Venda venda)
        {
            _context.Venda.Add(venda);
            _context.SaveChanges();
        }

        public void Atualizar(Venda venda)
        {
            _context.Entry(venda).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Entry(venda).State = EntityState.Detached;
        }

        public List<VendaPorUsuarioDto> ObterVendasPorUsuario()
        {
            return _context.Usuario.Include(e => e.Vendas).Select(e => new VendaPorUsuarioDto() { 
                Nome = e.Nome,
                QtdDeVendas = e.Vendas.Count(),
                ValorToralVendas = e.Vendas.Sum(e => e.Total),
                Vendas = e.Vendas
            }).ToList();
        }
    }
}
