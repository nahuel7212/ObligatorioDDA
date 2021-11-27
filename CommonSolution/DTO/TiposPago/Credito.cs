using CommonSolution.Interface.TipoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.TiposPago
{
    public class Credito : ITipoPago
    {
        public string Nombre { get; set; }
    }
}
