using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorbitPizzaApp.Api.Model;

namespace NorbitPizzaApp.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class StatusController : Controller
{
    private readonly NorbitPizzaContext _context;
    public StatusController(NorbitPizzaContext context)
    {
        _context = context;
    }
    // GET
    [HttpGet(Name = "GetStatuses")]
    public async Task<IEnumerable<Status>> Get()
    {
        return await _context.Statuses.ToListAsync();
    }
}