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
        public long id;
        public float lat;
        public float lgn;
        public string observaciones;
        public Estado Estado;
        public DateTime fechaHoraReclamo;


    }
}