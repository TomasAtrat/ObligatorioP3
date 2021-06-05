using CommonSolution.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TorneoRepository
    {
        public TorneoRepository()
        {

        }

        public bool ExisteTorneo(long id)
        {
            bool exists = false;
            using (DBEntities context= new DBEntities())
            {
                exists = context.Torneo.AsNoTracking().Any(i => i.idTorneo == id);
            }
            return exists;
        }

        public int JugadorGanadorTorneo(long idTorneo)
        {
            int id = 0;
            using (DBEntities context= new DBEntities())
            {
                
            }
        }
    }
}
