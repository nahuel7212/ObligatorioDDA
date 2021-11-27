using CommonSolution.DTO.Precios;
using CommonSolution.Interface.Precio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Clientes
{
    public class Persona : Cliente
    {
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public Direccion Direccion { get; set; }
        public IPrecioGeneral TipoPrecio { get; set; }
    }
}
