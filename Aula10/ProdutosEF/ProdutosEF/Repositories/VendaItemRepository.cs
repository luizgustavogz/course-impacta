using ProdutosEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEF.Repositories
{
    interface VendaItemRepository
    {
        void Salvar(VendaItem item);
    }
}
