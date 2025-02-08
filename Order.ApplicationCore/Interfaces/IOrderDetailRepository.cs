using Order.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.ApplicationCore.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId);
        Task<OrderDetail> AddOrderDetailAsync(OrderDetail orderDetail);
    }
}