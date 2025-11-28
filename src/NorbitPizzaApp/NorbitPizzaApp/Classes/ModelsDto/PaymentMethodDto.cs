using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorbitPizzaApp.Classes.ModelsDto
{
    public class PaymentMethodDto
    {
        public int PaymentMethodId { get; set; }

        public string? PaymentName { get; set; }

        public double? Discount { get; set; }
    }
}
