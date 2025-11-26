using System;
using System.Collections.Generic;

namespace NorbitPizzaApp.Api.Model;

public partial class PizzaFormat
{
    public int PizzaFormatId { get; set; }

    public int? FormatId { get; set; }

    public int? PizzaId { get; set; }

    public int? Weight { get; set; }

    public virtual Format? Format { get; set; }

    public virtual Product? Pizza { get; set; }
}
