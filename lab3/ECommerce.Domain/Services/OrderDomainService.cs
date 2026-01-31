using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Services
{
    public class OrderDomainService
    {
        public bool CanPlaceOrder(Customer customer, List<OrderItem> items)
        {
            // Business logic: e.g., customer must exist, items should be in stock, etc.
            return customer != null && items != null && items.Count > 0;
        }
    }
}


