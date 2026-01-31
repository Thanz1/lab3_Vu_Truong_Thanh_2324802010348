using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product mappings
            CreateMap<Product, ProductDTO>();
            CreateMap<CreateProductDTO, Product>();

            // Order mappings
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();

            // Address mapping
            CreateMap<Address, AddressDTO>();
        }
    }
}


