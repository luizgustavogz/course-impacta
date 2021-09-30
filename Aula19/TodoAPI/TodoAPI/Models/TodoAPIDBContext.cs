using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TodoAPI.Models
{
    public class TodoAPIDBContext : DbContext
    {
        public DbSet<TodoItem> todoItem { get; set; }

        public TodoAPIDBContext(DbContextOptions<TodoAPIDBContext> options)
            : base(options)
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
