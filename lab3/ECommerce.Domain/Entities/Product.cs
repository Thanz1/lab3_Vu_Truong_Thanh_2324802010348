using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required, MaxLength(200)]
        public string Name { get; private set; } = null!;

        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; private set; }

        [MaxLength(1000)]
        public string? Description { get; private set; }

        public int StockQuantity { get; private set; }

        // Navigation property for OrderItems referencing this product (optional)
        public ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

        private Product() { } // EF Core needs parameterless constructor

        public Product(string name, decimal price, int stockQuantity, string? description)
        {
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
            Description = description;
        }

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Price must be positive");
            Price = newPrice;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity > StockQuantity)
                throw new InvalidOperationException("Insufficient stock");
            StockQuantity -= quantity;
        }
    }
}


