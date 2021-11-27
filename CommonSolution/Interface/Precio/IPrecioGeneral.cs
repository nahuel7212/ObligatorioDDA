using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Interface.Precio
{
    public interface IPrecioGeneral
    {
        string Nombre { get; set; }
        double ValorPrestablecido { get; set; }
        double PrecioTotal(double kilogramos, double kilometros);
    }
}
