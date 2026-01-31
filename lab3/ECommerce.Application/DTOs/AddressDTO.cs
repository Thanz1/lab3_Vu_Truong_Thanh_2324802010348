using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTOs
{
    public class AddressDTO
    {
        [Required, MaxLength(250)]
        public string Street { get; set; } = null!;

        [Required, MaxLength(100)]
        public string City { get; set; } = null!;

        [Required, MaxLength(100)]
        public string State { get; set; } = null!;

        [Required, MaxLength(20)]
        public string PostalCode { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Country { get; set; } = null!;
    }
}


