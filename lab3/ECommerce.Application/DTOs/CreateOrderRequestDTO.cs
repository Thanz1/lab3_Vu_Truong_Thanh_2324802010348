using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTOs
{
    public class CreateOrderRequestDTO
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public AddressDTO ShippingAddress { get; set; } = null!;

        [Required]
        [MinLength(1, ErrorMessage = "At least one order item is required")]
        public List<OrderItemRequestDTO> Items { get; set; } = new();
    }
}


