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
    
    public partial class t_HISTORICO_ESTADO_RECLAMO
    {
        public long ID { get; set; }
        public string EstadoAnterior { get; set; }
        public string EstadoActual { get; set; }
        public System.DateTime FechaHoraCambio { get; set; }
        public string Comentarios { get; set; }
        public System.DateTime FechaHoraIngreso { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public long IDReclamo { get; set; }
        public string DescripcionReclamo { get; set; }
        public Nullable<long> IDCuadrilla { get; set; }
    }
}
