//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Envio
    {
        public long ID { get; set; }
        public int NroTracking { get; set; }
        public double PrecioTotal { get; set; }
        public string Estado { get; set; }
        public string IDFuncionario { get; set; }
        public long IDCliente { get; set; }
        public long IDTipoPago { get; set; }
        public string IDCamion { get; set; }
        public long IDZona { get; set; }
        public long IDDireccion { get; set; }
    
        public virtual T_Camion T_Camion { get; set; }
        public virtual T_Cliente T_Cliente { get; set; }
        public virtual T_Direccion T_Direccion { get; set; }
        public virtual T_Funcionario T_Funcionario { get; set; }
        public virtual T_TipoPago T_TipoPago { get; set; }
        public virtual T_Zona T_Zona { get; set; }
    }
}
