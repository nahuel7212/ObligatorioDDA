using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Interface.TipoPago
{
    public interface ITipoPago
    {
        long Id { get; set; }
        string Nombre { get; set; }
    }
}
