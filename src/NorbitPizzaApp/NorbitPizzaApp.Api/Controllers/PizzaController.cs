using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorbitPizzaApp.Api.Model;

namespace NorbitPizzaApp.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class PizzaController : Controller
{
    
    private readonly NorbitPizzaContext _context;
    public PizzaController(NorbitPizzaContext context)
    {
        _context = context;
    }
    // GET
    [HttpGet(Name = "GetPizza")]
    public async Task<IEnumerable<Product>> Get()
    {
        return await _context.Products.ToListAsync();
    }
    [HttpGet("GetByCategory/{id}")]
    public ActionResult<IEnumerable<Product>> GetByCategory(int id)
    {
        int?[] productIds = _context.ProductCategories.Where(p => p.CategoryId == id).Select(p => p.ProductId).ToArray();
        List<Product> products = _context.Products.Where(p => productIds.Contains(p.ProductId)).ToList();
        if (products.Count == 0)
        {
            return NotFound();
        }
        return products;
    }
    [HttpGet("GetByIngredients/{ingredients}")]
    public ActionResult<IEnumerable<Product>> GetByIngredients(List<Ingredient> ingredients)
    {
        int[] ingredientsIds = ingredients.Select(p => p.IngredientId).ToArray();
        int?[] productIds = _context.ProductIngredients.ToList().Where(p => ingredientsIds.Contains(p.IngredientId.Value)).Select(p => p.ProductId).ToArray();
        List<Product> products = _context.Products.Where(p => productIds.Contains(p.ProductId)).ToList();
        if (products.Count == 0)
        {
            return NotFound();
        }
        return products;
    }
}