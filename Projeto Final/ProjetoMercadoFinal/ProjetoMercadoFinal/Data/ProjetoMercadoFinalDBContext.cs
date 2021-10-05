using Microsoft.EntityFrameworkCore;
using ProjetoMercadoFinal.Models;
using System.Linq;

namespace ProjetoMercadoFinal.Models
{
    public class ProjetoMercadoFinalDBContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaItem> VendaItem { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public ProjetoMercadoFinalDBContext(DbContextOptions<ProjetoMercadoFinalDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
