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

       //public List<DtoReclamo> PuntosReclamos(DateTime inicio, DateTime fin)
       // {
       //     List<DtoReclamo> colpuntos = new List<DtoReclamo>();
           
       //     colpuntos = this.repository.ReclamoRepository.reclamoPorFecha(inicio, fin);


       //     return colpuntos;

       // }
            


    }
}
