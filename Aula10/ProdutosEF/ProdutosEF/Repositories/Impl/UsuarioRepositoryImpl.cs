using ProdutosEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEF.Repositories.Impl
{
    class UsuarioRepositoryImpl : UsuarioRepository
    {
        private ProdutosEFDBContext _context;

        public UsuarioRepositoryImpl(ProdutosEFDBContext context)
        {
            _context = context;
        }

        public Usuario SelecionarPorId(int idUsuario)
        {
            return _context.Usuario.FirstOrDefault(usuario => usuario.Id == idUsuario);
        }
    }
}
