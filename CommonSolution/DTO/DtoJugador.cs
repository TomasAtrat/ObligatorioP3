using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    public class DtoJugador
    {
        public int NumJugador ;
        public string nombre ;
        public string apellido ;
        public string documento ;
        public List<DtoPartido> dtoPartidos;
    }
}
