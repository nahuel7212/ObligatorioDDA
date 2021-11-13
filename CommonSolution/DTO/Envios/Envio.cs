using CommonSolution.DTO.Camiones;
using CommonSolution.DTO.Clientes;
using CommonSolution.DTO.Funcionarios;
using CommonSolution.ENUM;
using CommonSolution.Interface.TipoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO.Envios
{
    public class Envio
    {
        public long Id { get; set; }
        public ITipoPago TipoPago { get; set; }
        public string NumeroTracking { get; set; }
        public EstadoEnvio Estado { get; set; }
        public double PrecioTotal { get; set; }
        public double PesoTotal { get; set; }
        public DateTime FechaAgregado { get; set; }
        public string DescripcionContenido { get; set; }
        public Funcionario Responsable { get; set; }
        public Cliente Remitente { get; set; }
        public Cliente Destinatario { get; set; }
        public Zona ZonaEnvio { get; set; }
        public Camion CamionEnvio { get; set; }
        public Direccion DireccionEnvio { get; set; }

        public double CalcularPrecioTotal()
        {
            return 0;
        }
    }
}
