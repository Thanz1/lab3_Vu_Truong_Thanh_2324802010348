using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain.Entities
{
    public class OrderItem
    {
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }

        [MaxLength(200)]
        public string? ProductName { get; private set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal UnitPrice { get; private set; }

        public int Quantity { get; private set; }

        public Order Order { get; private set; } = null!;

        private OrderItem() { } // EF Core

        public OrderItem(int productId, string productName, decimal unitPrice, int quantity, Order order)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Order = order ?? throw new ArgumentNullException(nameof(order));
            // OrderId will be set automatically by EF Core when Order is saved
        }

        public void IncreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}


