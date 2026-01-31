using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public int CustomerId { get; private set; }

        public DateTime OrderDate { get; private set; }

        public Address ShippingAddress { get; private set; } = null!;

        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalAmount { get; private set; }

        // Navigation to Customer
        public Customer Customer { get; private set; } = null!;

        // Navigation collection for OrderItems
        public ICollection<OrderItem> Items { get; private set; } = new List<OrderItem>();

        private Order() { }

        public Order(int customerId, Address shippingAddress)
        {
            CustomerId = customerId;
            ShippingAddress = shippingAddress;
            OrderDate = DateTime.UtcNow;
        }

        public void AddItem(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (product.StockQuantity < quantity)
                throw new InvalidOperationException("Not enough stock");

            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.IncreaseQuantity(quantity);
            }
            else
            {
                Items.Add(new OrderItem(product.Id, product.Name, product.Price, quantity, this));
            }

            product.ReduceStock(quantity);
            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = Items.Sum(i => i.UnitPrice * i.Quantity);
        }
    }
}


