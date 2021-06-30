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
        public long id {get; set;}
        public long idZona {get; set;}
        public string lat {get; set;}
        public string lng {get; set;}
    }
}
