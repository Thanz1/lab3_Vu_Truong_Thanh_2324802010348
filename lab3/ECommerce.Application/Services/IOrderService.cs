using ECommerce.Application.DTOs;

namespace ECommerce.Application.Services
{
    public interface IOrderService
    {
        Task<int> PlaceOrderAsync(CreateOrderRequestDTO orderRequest);
        Task<OrderDTO?> GetOrderByIdAsync(int orderId);
    }
}


