using CommonSolution.DTO.Envios;
using CommonSolution.ENUM;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class EnvioMapper
    {
        public T_Envio MapToEntity(Envio envio, bool mapId = false)
        {
            T_Envio entity = new T_Envio()
            {
                IDRemitente = envio.Remitente.IdCliente,
                IDDestinatario = envio.Destinatario.IdCliente,
                IDDireccion = envio.DireccionEnvio.IdDireccion,
                IDFuncionario = envio.Responsable.Documento,
                IDZona = envio.ZonaEnvio.IdZona,
                IDCamion = envio.CamionEnvio.Matricula,
                PrecioTotal = envio.PrecioTotal,
                PesoTotal = envio.PesoTotal,
                NroTracking = envio.NumeroTracking,
                IDTipoPago = envio.TipoPago.Nombre,
                Estado = EstadoToString(envio.Estado)
            };

            if (mapId)
                entity.ID = envio.IdEnvio;

            return entity;
        }

        public string EstadoToString(EstadoEnvio estado)
        {
            switch (estado)
            {
                case EstadoEnvio.EnDesposito:
                    return "EnDesposito";
                case EstadoEnvio.EnCamion:
                    return "EnCamion";
                case EstadoEnvio.Entregado:
                    return "Entregado";
                case EstadoEnvio.Eliminado:
                    return "Eliminado";
                default:
                    return "Unknown";
            }
        }
    }
}
