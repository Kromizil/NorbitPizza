using NorbitPizzaApp.Classes.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorbitPizzaApp.Classes.Model
{
    public partial class ProductCategory
    {
        public int? ProductId { get; set; }

        public int? CategoryId { get; set; }

        public int ProductCategoryId { get; set; }

        public virtual CategoryDto? Category { get; set; }

        public virtual Product? Product { get; set; }
    }
}
