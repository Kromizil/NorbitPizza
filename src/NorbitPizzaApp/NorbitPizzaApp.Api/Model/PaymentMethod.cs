using System;
using System.Collections.Generic;

namespace NorbitPizzaApp.Api.Model;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string? PaymentName { get; set; }

    public double? Discount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
