using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Dto
{
    public class DtoHistoricoReclamo : IDto
    {
        public long ID { get; set; }
        public string EstadoAnterior { get; set; }
        public string EstadoActual { get; set; }
        public DateTime FechaHoraCambio { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaHoraIngreso { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public long IDReclamo { get; set; }
        public string DescripcionReclamo { get; set; }
    }
}