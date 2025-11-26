using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorbitPizzaApp.Api.Model;

namespace NorbitPizzaApp.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class PizzaFormatController : Controller
{
    private readonly NorbitPizzaContext _context;
    public PizzaFormatController(NorbitPizzaContext context)
    {
        _context = context;
    }
    // GET
    [HttpGet(Name = "GetPizzaFormat")]
    public async Task<IEnumerable<Format>> Get()
    {
        return await _context.Formats.ToListAsync();
    }
}