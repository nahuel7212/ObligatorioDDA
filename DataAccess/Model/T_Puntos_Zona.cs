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
    
    public partial class T_Puntos_Zona
    {
        public long IDPunto { get; set; }
        public long NumeroZona { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    
        public virtual T_Zona T_Zona { get; set; }
    }
}
