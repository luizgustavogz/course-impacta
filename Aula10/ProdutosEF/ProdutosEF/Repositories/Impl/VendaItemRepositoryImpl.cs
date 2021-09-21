using ProdutosEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEF.Repositories.Impl
{
    class VendaItemRepositoryImpl : VendaItemRepository
    {
        private ProdutosEFDBContext _context;

        public VendaItemRepositoryImpl(ProdutosEFDBContext context)
        {
            _context = context;
        }

        public void Salvar(VendaItem item)
        {
            _context.VendaItem.Add(item);
            _context.SaveChanges();
        }
    }
}
