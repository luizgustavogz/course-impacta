using ProdutosEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEF.Repositories.Impl
{
    class ProdutoRepositoryImpl : ProdutoRepository
    {
        private ProdutosEFDBContext _context;

        public ProdutoRepositoryImpl(ProdutosEFDBContext context)
        {
            _context = context;
        }

        public List<Produto> ObterProdutos()
        {
            return _context.Produto.Where(produto => produto.Validade > DateTime.Now).ToList();
        }

        public Produto SelecionarProdutoPorId(int idProduto)
        {
            return _context.Produto.FirstOrDefault(produto => produto.Id == idProduto);
        }
    }
}
