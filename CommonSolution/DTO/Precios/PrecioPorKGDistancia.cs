using CommonSolution.Interface.Precio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Precios
{
    public class PrecioPorKGDistancia : IPrecioGeneral
    {
        public string Nombre { get; set; }
        public double ValorPrestablecido { get; set; }
        public double Peso { get; set; }
        public double DistanciaKM { get; set; }

        public double PrecioTotal(double kilogramos, double kilometros)
        {
            //25% del precio por KG x la cantidad de KM a recorrer para la entrega
            double ValorVeinticintoPorciento = (this.ValorPrestablecido * 25) / 100;
            double ValorFinal = (ValorVeinticintoPorciento * kilogramos) * kilometros;

            return ValorFinal;
        }
    }
}
