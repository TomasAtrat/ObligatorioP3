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
    
    public partial class t_RECLAMO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_RECLAMO()
        {
            this.t_USUARIO = new HashSet<t_USUARIO>();
        }
    
        public long ID { get; set; }
        public long IDZona { get; set; }
        public long IDCuadrilla { get; set; }
        public long IDTipoReclamo { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> FechaHoraIngreso { get; set; }
        public string Observaciones { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public Nullable<bool> EstadoL { get; set; }
    
        public virtual t_TIPO_RECLAMO t_TIPO_RECLAMO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_USUARIO> t_USUARIO { get; set; }
        public virtual t_CUADRILLA_ZONA t_CUADRILLA_ZONA1 { get; set; }
    }
}
