using ProdutosEF.Models;
using System;
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
    }
}
