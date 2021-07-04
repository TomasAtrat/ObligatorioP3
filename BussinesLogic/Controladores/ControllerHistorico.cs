using CommonSolution.Dto;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controladores
{
    public class ControllerHistorico
    {
        public ControllerHistorico()
        {
            this.repository = new Repository();
        }

        private Repository repository;

        public List<DtoHistoricoReclamo> getElements()
        {
            return this.repository.Historico_Repository.getElements();          
        }

        public List<DtoHistoricoReclamo> getElementsByFK(long id)
        {
            return this.repository.Historico_Repository.getElementsByFK(id);
        }
    }
}
