using Microsoft.EntityFrameworkCore;
using Order_CRUD.Entities;

namespace Order_CRUD.Database
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(b => b.Email)
                .IsUnique();
        }
    }
}
