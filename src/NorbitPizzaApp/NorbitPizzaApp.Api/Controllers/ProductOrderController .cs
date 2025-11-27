using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorbitPizzaApp.Api.Model;

namespace NorbitPizzaApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductOrderController : Controller
    {
        private readonly NorbitPizzaContext _context;

        public ProductOrderController(NorbitPizzaContext context)
        {
            _context = context;
        }

        // Именованный маршрут для последующего CreatedAtRoute
        [HttpGet("{id}", Name = "GetProductOrderById")]
        public async Task<ActionResult<ProductOrder>> GetProductOrder(int id)
        {
            if (_context.ProductOrders == null)
                return NotFound();

            var productOrder = await _context.ProductOrders.FindAsync(id);
            if (productOrder == null)
                return NotFound();

            return productOrder;
        }

        [HttpPost]
        public async Task<ActionResult<ProductOrder>> PostProductOrder(ProductOrder productOrder)
        {
            if (_context.ProductOrders == null)
                return Problem("Entity set 'NorbitPizzaContext.ProductOrders' is null.");

            _context.ProductOrders.Add(productOrder);
            await _context.SaveChangesAsync();

            // Возвращаем Created по именованному маршруту
            return CreatedAtRoute("GetProductOrderById", new { id = productOrder.ProductOrderId }, productOrder);
        }
    }
}
