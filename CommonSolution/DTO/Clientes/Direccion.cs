using CommonSolution.DTO.Camiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Clientes
{
    public class Direccion
    {
        public long IdDireccion { get; set; }
        public string Nombre { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public Zona Zona { get; set; }
    }
}
