using NorbitPizzaApp.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorbitPizzaApp.Classes.ModelsDto
{
    public class DataContainer
    {
        public List<ProductDto> Pizzas { get; set; } = new();
        public List<Ingredient> Ingredients { get; set; } = new();
        public List<CategoryDto> Category { get; set; } = new();

    }
}
