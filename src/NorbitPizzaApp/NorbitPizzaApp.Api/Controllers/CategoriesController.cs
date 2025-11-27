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

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Category>> GetCategorysById(int id)
    {
        int?[] CategoryIds = _context.ProductCategories.Where(p => p.ProductId == id).Select(p => p.CategoryId).ToArray();
        List<Category> categories = _context.Categories.Where(p => CategoryIds.Contains(p.CategoryId)).ToList();
        if (categories.Count == 0)
        {
            return NotFound();
        }
        return categories;
    }
}