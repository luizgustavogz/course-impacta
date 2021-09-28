using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MercadoMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MercadoMVC.Data
{
    public class MercadoMVCContext : IdentityDbContext
    {
        public MercadoMVCContext (DbContextOptions<MercadoMVCContext> options)
            : base(options)
        {
        }

        public DbSet<MercadoMVC.Models.Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<MercadoMVC.Models.Venda> Venda { get; set; }
        public DbSet<MercadoMVC.Models.VendaItem> VendaItem { get; set; }
    }
}
