using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    public class DtoTorneo
    {
        public long idTorneo ;
        public string Nombre ;
        public Nullable<DateTime> Inicio ;
        public Nullable<DateTime> Fin ;
        public List<DtoPartido> colPartidos;
    }
}
