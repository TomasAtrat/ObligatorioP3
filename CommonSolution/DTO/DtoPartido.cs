using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    public class DtoPartido
    {
        public int idPartido ;
        public int idJugador1 ;
        public int idJugador2 ;
        public Nullable<short> PuntosJugador1 ;
        public Nullable<short> PuntosJugador2 ;
        public Nullable<DateTime> FechaHoraInicio ;
        public Nullable<DateTime> FechaHoraFin ;
        public long idTorneo ;
    }
}
