using Order.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Entities.Order>> GetAllOrdersAsync();
        Task<Entities.Order> GetOrderByIdAsync(int id);
        Task<IEnumerable<Entities.Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<Entities.Order> CreateOrderAsync(Entities.Order order);
        Task<Entities.Order> UpdateOrderAsync(Entities.Order order);
        Task DeleteOrderAsync(int id);
    }
}