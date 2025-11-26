using System;
using System.Collections.Generic;

namespace NorbitPizzaApp.Api.Model;

public partial class ProductIngredient
{
    public int? ProductId { get; set; }

    public int? IngredientId { get; set; }

    public int ProductIngridientId { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual Product? Product { get; set; }
}
