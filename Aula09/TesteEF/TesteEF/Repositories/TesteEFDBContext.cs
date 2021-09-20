using Microsoft.EntityFrameworkCore;
using System.Linq;
using TesteEF.Models;

namespace TesteEF
{
    class TesteEFDBContext : DbContext
    {
        public DbSet<Blog> Blog { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=RECSP-SRV-BDD1.fcrecovery.com.ar,1344;Database=Vuelcos;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
