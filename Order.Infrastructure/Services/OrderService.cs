using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public async Task<IEnumerable<ApplicationCore.Entities.Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }
        
        public async Task<ApplicationCore.Entities.Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetOrderByIdAsync(id);
        }
        
        public async Task<IEnumerable<ApplicationCore.Entities.Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _orderRepository.GetOrdersByCustomerIdAsync(customerId);
        }
        
        public async Task<ApplicationCore.Entities.Order> CreateOrderAsync(ApplicationCore.Entities.Order order)
        {
            // Additional business logic could go here
            return await _orderRepository.AddOrderAsync(order);
        }
        
        public async Task<ApplicationCore.Entities.Order> UpdateOrderAsync(ApplicationCore.Entities.Order order)
        {
            return await _orderRepository.UpdateOrderAsync(order);
        }
        
        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
        }
    }
}