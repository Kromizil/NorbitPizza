using Microsoft.AspNetCore.Mvc;
using NorbitPizzaApp.Api.Model;

namespace NorbitPizzaApp.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class IngredientsController : Controller
{
    private readonly NorbitPizzaContext _context;
    public IngredientsController(NorbitPizzaContext context)
    {
        _context = context;
    }
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Ingredient>> GetIngredientsById(int id)
    {
        int?[] ingredientsIds = _context.ProductIngredients.Where(p => p.ProductId == id).Select(p => p.IngredientId).ToArray();
        List<Ingredient> ingredients = _context.Ingredients.Where(p => ingredientsIds.Contains(p.IngredientId)).ToList();
        if (ingredients.Count == 0)
        {
            return NotFound();
        }
        return ingredients;
    }
}