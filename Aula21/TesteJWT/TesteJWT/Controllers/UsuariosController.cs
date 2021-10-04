using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteJWT.Models;
using System.Security.Cryptography;
using System.Text;
using TesteJWT.Utils;
using TesteJWT.Dto;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TesteJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly TesteJWTDBContext _context;

        public UsuariosController(TesteJWTDBContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> PutUsuario(int id, SalvarUsuarioDto dto)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return BadRequest("Usuário não encontrado");
            }

            usuario.Nome = dto.Nome;
            usuario.Perfil = dto.Perfil;
            usuario.Email = dto.Email;
            usuario.Senha = PasswordUtil.GeneratePassword(dto.Senha);

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<Usuario>> CadastroPublico(SalvarUsuarioDto dto)
        {
            if (string.IsNullOrEmpty(dto.Senha) || string.IsNullOrWhiteSpace(dto.Senha))
            {
                return BadRequest("Favor informar todos os dados");
            }

            var usuario = new Usuario()
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = PasswordUtil.GeneratePassword(dto.Senha),
                Perfil = "USER"
            };

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(SalvarUsuarioDto dto)
        {
            var idUsuarioLogged = User.Claims.Where(e => e.Type == ClaimTypes.Sid).Select(e => e.Value).FirstOrDefault();

            Usuario logged = null;
            if (!string.IsNullOrEmpty(idUsuarioLogged))
            {
                logged = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == int.Parse(idUsuarioLogged));
            }

            if (string.IsNullOrEmpty(dto.Senha) || string.IsNullOrWhiteSpace(dto.Senha))
            {
                return BadRequest("Favor informar todos os dados");
            }

            var usuario = new Usuario()
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = PasswordUtil.GeneratePassword(dto.Senha)
            };

            if (logged != null && logged.Perfil == "ADMIN")
            {
                usuario.Perfil = dto.Perfil;
            }
            else
            {
                usuario.Perfil = "USER";
            }

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
