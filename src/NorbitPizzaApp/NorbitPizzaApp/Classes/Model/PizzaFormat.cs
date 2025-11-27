using NorbitPizzaApp.Classes.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorbitPizzaApp.Classes.Model
{
    public partial class PizzaFormat
    {
        public int PizzaFormatId { get; set; }

        public int? FormatId { get; set; }

        public int? PizzaId { get; set; }

        public int? Weight { get; set; }

        public virtual FormatDTO? Format { get; set; }

        public virtual Product? Pizza { get; set; }



    }
}

