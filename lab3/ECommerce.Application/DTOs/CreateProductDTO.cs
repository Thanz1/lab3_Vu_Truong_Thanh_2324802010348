using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTOs
{
    public class CreateProductDTO
    {
        [Required, MaxLength(200)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
    }
}


