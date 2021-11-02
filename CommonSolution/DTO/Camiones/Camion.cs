using CommonSolution.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Camiones
{
    public class Camion
    {
        public string Matricula { get; set; }
        public EstadoCamion Estado { get; set; }
        public short Capacidad { get; set; }
        public List<Zona> Zona { get; set; }
        public Ruta Ruta { get; set; }
    }
}
