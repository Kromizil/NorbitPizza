using System;
using System.Collections.Generic;

namespace NorbitPizzaApp.Api.Model;

public partial class ProductOrder
{
    public int ProductOrderId { get; set; }

    public int ProductId { get; set; }

    public int BasketId { get; set; }

    public int Count { get; set; }

    public virtual Order Basket { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
