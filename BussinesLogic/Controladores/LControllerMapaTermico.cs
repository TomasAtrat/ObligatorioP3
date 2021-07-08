using CommonSolution.Dto;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controladores
{
   public class LControllerMapaTermico
    {

        public LControllerMapaTermico()
        {
            this.repository = new Repository();
        }
        private Repository repository;

       public List<DtoPunto> PuntosReclamos(DateTime inicio, DateTime fin)
        {
            List<DtoReclamo> colpuntos = new List<DtoReclamo>();
            List<DtoPunto> puntos = new List<DtoPunto>();
            DtoPunto punto = new DtoPunto ();
            colpuntos = this.repository.ReclamoRepository.reclamoPorFecha(inicio, fin);

            foreach (DtoReclamo item in colpuntos)
            {
                punto.lat = item.Latitud;
                punto.lng = item.Longitud;

                puntos.Add(punto);

            }

            return puntos;

        }
            


    }
}
