using System;
using System.Collections.Generic;

namespace NorbitPizzaApp.Api.Model;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string? IngredientName { get; set; }

    public virtual ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();
}
