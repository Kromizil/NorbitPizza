using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorbitPizzaApp.Api.Model;

namespace NorbitPizzaApp.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class OrderController : Controller
{
    private readonly NorbitPizzaContext _context;
    public OrderController(NorbitPizzaContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<ActionResult<Order>> PostVacation(Order order)
    {
        if (_context.Orders == null)
        {
            return Problem("Entity set 'NorbitPizzaApp.Orders'  is null.");
        }
        _context.Orders.Add(order);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (OrderExists(order.OrderId))
            {
                return Conflict();
            }
            else
            {
                throw;
            }
        }

        return CreatedAtAction("GetVacation", new { id = order.OrderId }, order);
    }
    private bool OrderExists(int id)
    {
        return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
    }
}