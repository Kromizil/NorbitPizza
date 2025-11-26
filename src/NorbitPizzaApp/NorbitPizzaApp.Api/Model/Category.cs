using System;
using System.Collections.Generic;

namespace NorbitPizzaApp.Api.Model;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}
