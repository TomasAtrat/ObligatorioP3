using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Dto
{
    public enum Estado { PENDIENTE, ASIGNADO, EN_PROCESO, RESUELTO, DESESTIMADO };
    public class DtoReclamo : IDto
    {
        public Estado Estado;
        public long ID { get; set; }
        public long IDZona { get; set; }
        public long IDCuadrilla { get; set; }
        public long IDTipoReclamo { get; set; }
        public Nullable<DateTime> FechaHoraIngreso { get; set; }
        public string Observaciones { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public List<DtoUsuario> colUsuarios;
    }
}