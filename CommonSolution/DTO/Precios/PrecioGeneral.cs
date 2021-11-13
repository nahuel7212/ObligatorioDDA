using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Precios
{
    public abstract class PrecioGeneral
    {
        public bool Estado { get; set; }

        public abstract double PrecioTotal();
    }
}
