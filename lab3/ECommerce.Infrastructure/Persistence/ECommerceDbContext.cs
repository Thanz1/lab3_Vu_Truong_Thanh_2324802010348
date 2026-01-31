using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Persistence
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Address as Value Object for Customer and Order
            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);
            modelBuilder.Entity<Order>().OwnsOne(o => o.ShippingAddress);

            //Composite Primary Key 
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            //Specifying the Custom column names for Owned Entity properties
            //By Default: ShippingAddress_Street, ShippingAddress_City, etc.
            //Changing to: Street, City, etc.
            modelBuilder.Entity<Order>(builder =>
            {
                builder.OwnsOne(o => o.ShippingAddress, sa =>
                {
                    sa.Property(p => p.Street).HasColumnName("Street");
                    sa.Property(p => p.City).HasColumnName("City");
                    sa.Property(p => p.State).HasColumnName("State");
                    sa.Property(p => p.PostalCode).HasColumnName("PostalCode");
                    sa.Property(p => p.Country).HasColumnName("Country");
                });
            });

            modelBuilder.Entity<Customer>(builder =>
            {
                builder.OwnsOne(c => c.Address, a =>
                {
                    a.Property(p => p.Street).HasColumnName("Street");
                    a.Property(p => p.City).HasColumnName("City");
                    a.Property(p => p.State).HasColumnName("State");
                    a.Property(p => p.PostalCode).HasColumnName("PostalCode");
                    a.Property(p => p.Country).HasColumnName("Country");
                });
            });

            // Seed Customers (owner entity)
            modelBuilder.Entity<Customer>().HasData(
                new { Id = 1, FirstName = "Pranaya", LastName = "Rout", Email = "pranaya@example.com" },
                new { Id = 2, FirstName = "Priyanka", LastName = "Sharma", Email = "priyanka@example.com" }
            );

            // Seed Addresses (owned entity) separately, link via CustomerId
            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address).HasData(
                new
                {
                    CustomerId = 1,
                    Street = "123 Main Road",
                    City = "Bhubaneswar",
                    State = "Odisha",
                    PostalCode = "751024",
                    Country = "India"
                },
                new
                {
                    CustomerId = 2,
                    Street = "45 Park Avenue",
                    City = "Delhi",
                    State = "Delhi",
                    PostalCode = "110001",
                    Country = "India"
                }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new { Id = 1, Name = "Apple iPhone 15", Price = 70000m, StockQuantity = 50, Description = "Latest iPhone with A17 chip and improved camera." },
                new { Id = 2, Name = "Samsung Galaxy S24", Price = 65000m, StockQuantity = 70, Description = "Flagship Samsung with dynamic AMOLED display." },
                new { Id = 3, Name = "OnePlus Nord 4", Price = 32000m, StockQuantity = 80, Description = "Affordable 5G smartphone with smooth performance." }
            );
        }
    }
}


