using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorbitPizzaApp.Api.Model;

namespace NorbitPizzaApp.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly NorbitPizzaContext _context;
    public CategoriesController(NorbitPizzaContext context)
    {
        _context = context;
    }
    // GET
    [HttpGet(Name = "GetCategories")]
    public async Task<IEnumerable<Category>> Get()
    {
        return await _context.Categories.ToListAsync();
    }
}