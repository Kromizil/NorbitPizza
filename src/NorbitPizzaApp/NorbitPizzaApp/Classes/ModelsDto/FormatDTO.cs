using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorbitPizzaApp.Classes.ModelsDto
{
    public class FormatDTO
    {
        public int FormatId { get; set; }

        public string? FormatName { get; set; }

        public decimal? PriceMultiplier { get; set; }

        public decimal CalculatedPrice { get; set; }

    }
}
