using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Interface.PrecioGeneral
{
    public interface IPrecioGeneral
    {
        bool EstadoGeneral { get; set; }

        double PrecioTotal();
    }
}
