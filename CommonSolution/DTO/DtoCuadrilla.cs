using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Dto
{
    public class DtoCuadrilla : IDto
    {
        public long id;
        public string encargado;
        public string nombre;
        public short cantidadPeones;
        public long idZona;
        public List<DtoReclamo> colReclamos;
    }
}
