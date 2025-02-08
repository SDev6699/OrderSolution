using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Interfaces;
using Order.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderDbContext _context;
        
        public OrderDetailRepository(OrderDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .ToListAsync();
        }
        
        public async Task<OrderDetail> AddOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }
    }
}