using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        // GET: api/order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationCore.Entities.Order>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
        
        // POST: api/order
        [HttpPost]
        public async Task<ActionResult<ApplicationCore.Entities.Order>> CreateOrder(ApplicationCore.Entities.Order order)
        {
            var createdOrder = await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.Id }, createdOrder);
        }
        
        // GET: api/order/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationCore.Entities.Order>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }
        
        // GET: api/order/customer/{customerId}
        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<ApplicationCore.Entities.Order>>> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);
            return Ok(orders);
        }
        
        // PUT: api/order/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApplicationCore.Entities.Order>> UpdateOrder(int id, ApplicationCore.Entities.Order order)
        {
            if (id != order.Id)
                return BadRequest("Order ID mismatch");
            
            var updatedOrder = await _orderService.UpdateOrderAsync(order);
            return Ok(updatedOrder);
        }
        
        // DELETE: api/order/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
