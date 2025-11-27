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
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Format>> GetPizzaFormatsById(int id)
    {
        int?[] FormatsIds = _context.PizzaFormats.Where(p => p.PizzaId == id).Select(p => p.FormatId).ToArray();
        List<Format> formats = _context.Formats.Where(p => FormatsIds.Contains(p.FormatId)).ToList();
        if (formats.Count == 0)
        {
            return NotFound();
        }
        return formats;
    }
}