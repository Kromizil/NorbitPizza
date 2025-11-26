using System;
using System.Collections.Generic;

namespace NorbitPizzaApp.Api.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public string? Address { get; set; }

    public string? Comment { get; set; }

    public int? PaymentMethod { get; set; }

    public string Phone { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public bool? IsPickup { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public double? TotalPrice { get; set; }

    public virtual PaymentMethod? PaymentMethodNavigation { get; set; }

    public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

    public virtual Status? StatusNavigation { get; set; }
}
