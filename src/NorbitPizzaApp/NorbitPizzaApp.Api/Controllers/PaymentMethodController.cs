using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorbitPizzaApp.Api.Model;

namespace NorbitPizzaApp.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class PaymentMethodController : Controller
{
    private readonly NorbitPizzaContext _context;
    public PaymentMethodController(NorbitPizzaContext context)
    {
        _context = context;
    }
    // GET
    [HttpGet(Name = "GetPayMethods")]
    public async Task<IEnumerable<PaymentMethod>> Get()
    {
        return await _context.PaymentMethods.ToListAsync();
    }
}