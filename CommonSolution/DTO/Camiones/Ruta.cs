using CommonSolution.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Camiones
{
    public class Ruta
    {
        public long Id { get; set; }
        public Direccion Direccion { get; set; }
    }
}
