using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteScaffold.Models;

namespace TesteScaffold.Data
{
    public class TesteScaffoldContext : DbContext
    {
        public TesteScaffoldContext (DbContextOptions<TesteScaffoldContext> options)
            : base(options)
        {
        }

        public DbSet<TesteScaffold.Models.Movie> Movie { get; set; }
    }
}
