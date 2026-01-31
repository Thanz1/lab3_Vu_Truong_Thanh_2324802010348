using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Domain.Entities
{
    [Owned]
    public sealed class Address
    {
        [Required, MaxLength(250)]
        public string Street { get; private set; } = null!;

        [Required, MaxLength(100)]
        public string City { get; private set; } = null!;

        [Required, MaxLength(100)]
        public string State { get; private set; } = null!;

        [Required, MaxLength(20)]
        public string PostalCode { get; private set; } = null!;

        [Required, MaxLength(100)]
        public string Country { get; private set; } = null!;

        private Address() { }

        public Address(string street, string city, string state, string postalCode, string country)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
        }
    }
}


