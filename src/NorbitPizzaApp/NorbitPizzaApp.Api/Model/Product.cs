using System;
using System.Collections.Generic;

namespace NorbitPizzaApp.Api.Model;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Comment { get; set; }

    public string? Image { get; set; }

    public decimal BasePrice { get; set; }

    public int ProductType { get; set; }

    public string? ImageName { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<PizzaFormat> PizzaFormats { get; set; } = new List<PizzaFormat>();

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();

    public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

    public virtual ProductType ProductTypeNavigation { get; set; } = null!;
}
