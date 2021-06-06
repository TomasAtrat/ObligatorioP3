using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Dto
{
    public class DtoPunto :IDto
    {
        public long id;
        public long idZona;
        public double lat;
        public double lng;
    }
}
