using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Camiones
{
    public class Zona
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public List<string> Latitud { get; set; }
        public List<string> Longitud { get; set; }
    }
}
