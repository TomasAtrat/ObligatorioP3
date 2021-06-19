using BussinesLogic.Interfaces;
using CommonSolution.Interfaces;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BussinesLogic.Controladores
{
    public class ControllerTipoReclamo : IControllers
    {
        public ControllerTipoReclamo()
        {
            this.repository = new Repository();
        }

        private Repository repository;

        public ActionResult Alta(IDto dto)
        {
            throw new NotImplementedException();
        }
        

        public List<string> Baja(IDto dto)
        {
            throw new NotImplementedException();
        }

        public List<string> Modificacion(IDto dto)
        {
            throw new NotImplementedException();
        }

        public List<IDto> ListAll()
        {
            return this.repository.TipoReclamoRepository.ListarTipoReclamo().Cast<IDto>().ToList();
        }
    }
}
