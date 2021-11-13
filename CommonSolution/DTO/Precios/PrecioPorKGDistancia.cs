using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Precios
{
    public abstract class PrecioPorKGDistancia : PrecioGeneral
    {
        public long IdPrecioKGDistancia { get; set; }
        public double Peso { get; set; }
        public double DistanciaKM { get; set; }

        public override double PrecioTotal()
        {
            return 0;
        }
    }
}
