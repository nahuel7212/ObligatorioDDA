using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Envios
{
    //Esta clase fue creada para llevar informacion de un nuevo envio en EnvioController y manejar esta informacion para crear un objeto envio
    // (solo se utiliza para pasamanos de datos)
    public class EnvioDataHolder
    {
        [DisplayName("Cliente remitente (Rut/Documento): ")]
        [Required(ErrorMessage = "Es necesario que indique el remitente")]
        public long RemitenteId { get; set; }

        [DisplayName("Cliente destinatario (Rut/Documento): ")]
        [Required(ErrorMessage = "Es necesario que indique el destinatario")]
        public long ClienteDestinatarioId { get; set; }

        [DisplayName("Peso total (en kilos): ")]
        [Required(ErrorMessage = "Es necesario indique el peso total")]
        public double PesoTotal { get; set; }

        [DisplayName("Descripcion contenido: ")]
        [StringLength(255, ErrorMessage = "Descripcion de contenido no puede superar {1} caracteres")]
        public string DescripcionContenido { get; set; }

        public string FuncionarioResponsable { get; set; }

        [DisplayName("Nombre: ")]
        [StringLength(255, ErrorMessage = "Nombre de zona no puede superar {1} caracteres")]
        public string NombreZona { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string DatoZona { get; set; }
        public double PrecioTotal { get; set; }
        public string TipoPago { get; set; }

        
    }
}
