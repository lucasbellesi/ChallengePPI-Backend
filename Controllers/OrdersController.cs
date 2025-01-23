using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChallengePPI.Backend.Data;
using ChallengePPI.Backend.Models;
using ChallengePPI.Backend.Services;

namespace ChallengePPI.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly OrderCalculationService _calculationService;

        public OrdersController(AppDbContext context, OrderCalculationService calculationService)
        {
            _context = context;
            _calculationService = calculationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound(new { message = "Order not found." });
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            var asset = await _context.Assets.FirstOrDefaultAsync(a => a.Name == order.AssetName);

            if (asset == null)
            {
                return BadRequest(new { message = "Invalid asset." });
            }

            try
            {
                order.TotalAmount = _calculationService.CalculateTotal(order, asset);
                order.Status = 0; // "En proceso"
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] Order updatedOrder)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound(new { message = "Order not found." });
            }

            order.Status = updatedOrder.Status;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound(new { message = "Order not found." });
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}