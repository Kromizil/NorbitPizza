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

    [HttpGet("{id}", Name = "GetVacationById")]
    public async Task<ActionResult<Order>> GetVacation(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return NotFound();
        return order;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> PostVacation(Order order)
    {
        if (_context.Orders == null)
            return Problem("Entity set 'NorbitPizzaApp.Orders' is null.");

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetVacationById", new { id = order.OrderId }, order);
    }
}