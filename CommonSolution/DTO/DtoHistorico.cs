using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Dto
{
    public class DtoHistoricoReclamo
    {
        public long id;
        public string estadoAnterior;
        public string estadoActual;
        public DateTime fechaHora;
        public string comentarios;
    }
}