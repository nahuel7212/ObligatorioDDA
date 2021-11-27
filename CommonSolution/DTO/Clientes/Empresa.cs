using CommonSolution.DTO.Precios;
using CommonSolution.Interface.Precio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Clientes
{
    public class Empresa : Cliente
    {
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; }
        public IPrecioGeneral TipoPrecio { get; set; }
    }
}
