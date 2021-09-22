using ProdutosEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEF.Dtos
{
    class VendaPorUsuarioDto
    {
        public string Nome { get; set; }
        public int QtdDeVendas { get; set; }
        public decimal ValorToralVendas { get; set; }
        public ICollection<Venda> Vendas { get; set; }
    }
}
