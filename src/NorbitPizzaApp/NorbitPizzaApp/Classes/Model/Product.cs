using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorbitPizzaApp.Classes.Model
{
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
    }
}
