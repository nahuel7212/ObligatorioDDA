using CommonSolution.DTO.Precios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Clientes
{
    public class Cliente
    {
        public long Id { get; set; }
        public Direccion Direccion { get; set; }
        public PrecioGeneral TipoPrecio { get; set; }
    }
}
