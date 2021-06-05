using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class JugadorRepository
    {
        public JugadorRepository()
        {

        }

        public bool existeJugador(int id)
        {
            bool exists = false;
            using (DBEntities context= new DBEntities())
            {
                exists = context.Jugador.AsNoTracking().Any(i => i.NumJugador == id);
            }
            return exists;
        }

        public int jugadorGanadorTorneo(long idTorneo)
        {
            Torneo tor = null;

            using (DBEntities context= new DBEntities())
            {
                tor = context.Torneo.Include("Partido").AsNoTracking().FirstOrDefault(i => i.idTorneo == idTorneo).Partido.OrderByDescending(o=>o.)  
            }
            foreach (var item in tor.Partido)
            {
                
            }
        }
    }
}
