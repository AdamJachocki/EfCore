using EfCoreHello.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;

namespace EfCoreHello
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());            
        }
    }
}
