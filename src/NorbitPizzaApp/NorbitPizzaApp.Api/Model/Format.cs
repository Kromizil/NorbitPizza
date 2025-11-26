using System;
using System.Collections.Generic;

namespace NorbitPizzaApp.Api.Model;

public partial class Format
{
    public int FormatId { get; set; }

    public string? FormatName { get; set; }

    public decimal? PriceMultiplier { get; set; }

    public virtual ICollection<PizzaFormat> PizzaFormats { get; set; } = new List<PizzaFormat>();
}
