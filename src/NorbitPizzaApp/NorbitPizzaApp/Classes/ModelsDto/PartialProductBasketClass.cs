using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorbitPizzaApp.Classes.ModelsDto
{
    public class PartialProductBasketClass
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal TotalPrice {  get; set; }

        public FormatDTO Format { get; set; } = new();
    }
}
