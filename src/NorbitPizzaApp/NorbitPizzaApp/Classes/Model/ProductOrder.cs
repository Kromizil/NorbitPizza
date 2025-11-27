using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorbitPizzaApp.Classes.Model
{
    public partial class ProductOrder
    {
        public int ProductOrderId { get; set; }

        public int ProductId { get; set; }

        public int BasketId { get; set; }

        public int Count { get; set; } = 1;

        public virtual Order Basket { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
