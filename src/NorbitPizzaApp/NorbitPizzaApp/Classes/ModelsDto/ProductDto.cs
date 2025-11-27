using NorbitPizzaApp.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorbitPizzaApp.Classes.ModelsDto
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? Comment { get; set; }

        public string? Image { get; set; }

        public decimal BasePrice { get; set; }

        public int ProductType { get; set; }

        public string? ImageName { get; set; }

        public string? Title { get; set; }

        public string? StringIngredient { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new();

        public List<CategoryDto> Categories { get; set; } = new();

        public List<FormatDTO> Formats { get; set; } = new();


    }
}
