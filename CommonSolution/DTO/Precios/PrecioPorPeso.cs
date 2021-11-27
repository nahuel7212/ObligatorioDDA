using CommonSolution.Interface.Precio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Precios
{
    public class PrecioPorPeso: IPrecioGeneral
    {
        public string Nombre { get; set; }
        public double ValorPrestablecido { get; set; }
        public double PesoKG { get; set; }


        public double PrecioTotal(double kilogramos, double kilometros)
        {
            return this.ValorPrestablecido * kilogramos;
        }
    }
}
