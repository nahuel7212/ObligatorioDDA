using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Precios
{
    public class PrecioFijo : PrecioGeneral
    {
        public long IdPrecioFijo { get; set; }
        
        public override double PrecioTotal()
        {
            return 0;
        }
    }
}
