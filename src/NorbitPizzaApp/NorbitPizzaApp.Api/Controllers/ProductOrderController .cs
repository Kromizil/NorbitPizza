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

        [HttpPost]
        public async Task<ActionResult<ProductOrder>> PostProductOrder(ProductOrder productOrder)
        {
            if (_context.ProductOrders == null)
            {
                return Problem("Entity set 'NorbitPizzaContext.ProductOrders' is null.");
            }

            _context.ProductOrders.Add(productOrder);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductOrderExists(productOrder.ProductOrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetProductOrder), new { id = productOrder.ProductOrderId }, productOrder);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOrder>> GetProductOrder(int id)
        {
            if (_context.ProductOrders == null)
            {
                return NotFound();
            }

            var productOrder = await _context.ProductOrders.FindAsync(id);

            if (productOrder == null)
            {
                return NotFound();
            }

            return productOrder;
        }

        private bool ProductOrderExists(int id)
        {
            return (_context.ProductOrders?.Any(e => e.ProductOrderId == id)).GetValueOrDefault();
        }
    }
}
