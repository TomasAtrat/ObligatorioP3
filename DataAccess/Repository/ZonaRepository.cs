using CommonSolution.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ZonaRepository
    {
        public ZonaRepository()
        {

        }

        public void AltaZona(DtoZona dto)
        {
            t_ZONA zona = new t_ZONA();
            using (Context context= new Context())
            {
                using (DbContextTransaction tran= context.Database.BeginTransaction(IsolationLevel.ReadCommitted) )
                {

                }
            }
        }
    }
}
