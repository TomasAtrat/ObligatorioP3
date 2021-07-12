using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Dto
{
    public enum Estado { PENDIENTE, ASIGNADO, EN_PROCESO, RESUELTO, DESESTIMADO };
    public class DtoReclamo : IDto
    {
        [Required]
        public Estado Estado;
        [Required]
        public string estado { get; set; }
        public long ID { get; set; }
        [DisplayName("ID de la zona")]
        public string IDZona { get; set; }
        [DisplayName("ID de la cuadrilla")]
        public long IDCuadrilla { get; set; }
        [Required]
        [DisplayName("Tipo de reclamo")]
        public long IDTipoReclamo { get; set; }
        [DisplayName("Fecha y hora del ingreso")]
        public Nullable<DateTime> FechaHoraIngreso { get; set; }
        [Required]
        [StringLength(250)]
        public string Observaciones { get; set; }
        [Required]
        public double Latitud { get; set; }
        [Required]
        public double Longitud { get; set; }
        [Required]
        [StringLength(250)]
        public string Comentarios { get; set; }
        public bool EstadoLogic;
        public List<DtoUsuario> colUsuarios;
        public DtoCuadrilla dtoCuadrilla;
        [DisplayName("Cuadrilla")]
        [Required(ErrorMessage = "Se debe especificar un directorio")]
        public string directorio { get; set; }
        public string inicio { get; set; }
        public string fin { get; set; }
    }
}