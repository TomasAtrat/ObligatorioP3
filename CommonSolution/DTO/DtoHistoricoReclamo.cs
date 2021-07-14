using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Dto
{
    public class DtoHistoricoReclamo : IDto
    {
        public long ID { get; set; }
        [DisplayName("Estado anterior")]
        public string EstadoAnterior { get; set; }
        [DisplayName("Estado actual")]
        public string EstadoActual { get; set; }
        [DisplayName("Fecha y hora del cambio")]
        public DateTime FechaHoraCambio { get; set; }
        public string Comentarios { get; set; }
        [DisplayName("Fecha y hora del ingreso")]
        public DateTime FechaHoraIngreso { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        [DisplayName("ID del reclamo")]
        public long IDReclamo { get; set; }
        [DisplayName("Descripción del reclamo")]
        public string DescripcionReclamo { get; set; }
        [DisplayName("Nombre del usuario")]
        public string nombreUsuario { get; set; }
    }
}