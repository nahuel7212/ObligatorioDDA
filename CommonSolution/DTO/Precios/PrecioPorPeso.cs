using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Precios
{
    public abstract class PrecioPorPeso: PrecioGeneral
    {
        public long IdPrecioPeso { get; set; }
        public double PesoKG { get; set; }


        public override double PrecioTotal()
        {
            return 0;
        }
    }
}
