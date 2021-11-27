using CommonSolution.Interface.Precio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Precios
{
    public class PrecioFijo : IPrecioGeneral
    {
        public string Nombre { get; set; }
        public double ValorPrestablecido { get; set; }


        //Valor prestablecido viene de base, cada grupo tiene su valor prestablecido en base
        public double PrecioTotal(double kilogramos, double kilometros)
        {
            return ValorPrestablecido;
        }
    }
}
