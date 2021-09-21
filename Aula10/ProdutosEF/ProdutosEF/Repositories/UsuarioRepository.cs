using ProdutosEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEF.Repositories
{
    interface UsuarioRepository
    {
        Usuario SelecionarPorId(int idUsuario);
    }
}
