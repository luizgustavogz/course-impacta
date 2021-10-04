using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteJWT.Models
{
    public class TesteJWTDBContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public TesteJWTDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
