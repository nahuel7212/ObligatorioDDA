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
    
    public partial class T_Direccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Direccion()
        {
            this.T_Empresa = new HashSet<T_Empresa>();
            this.T_Envio = new HashSet<T_Envio>();
            this.T_Persona = new HashSet<T_Persona>();
            this.T_Ruta_Direcciones = new HashSet<T_Ruta_Direcciones>();
        }
    
        public long ID { get; set; }
        public string Nombre { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Empresa> T_Empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Envio> T_Envio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Persona> T_Persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Ruta_Direcciones> T_Ruta_Direcciones { get; set; }
    }
}
