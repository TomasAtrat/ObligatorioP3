using DataAccess.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class Reportes
    {
        public Reportes()
        {
            this.reclamoReporte = new ReclamoReporte();
        }

        private ReclamoReporte reclamoReporte;

        public ReclamoReporte ReclamoReporte { get => reclamoReporte; set => reclamoReporte = value; }
    }
}
