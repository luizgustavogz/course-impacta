using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteScaffoldMVC.Models;

namespace TesteScaffoldMVC.Data
{
    public class TesteScaffoldMVCContext : DbContext
    {
        public TesteScaffoldMVCContext (DbContextOptions<TesteScaffoldMVCContext> options)
            : base(options)
        {
        }

        public DbSet<TesteScaffoldMVC.Models.Movie> Movie { get; set; }
    }
}
