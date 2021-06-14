using BussinesLogic.Interfaces;
using CommonSolution.Dto;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controladores
{
    public class ControllerReporte
    {
        public ControllerReporte()
        {
            this.repository = new Repository();
        }

        private Repository repository;

        public List<DtoReclamo> getReclamosAsignadosPorCuadrilla(long idCuadrilla)
        {
            List<DtoReclamo> colDtos = this.repository.ReclamoRepository.getElements();
            return colDtos.Where(i => i.IDCuadrilla == idCuadrilla && (i.Estado.ToString() == "ASIGNADO" || i.Estado.ToString() == "EN_PROCESO")).ToList();
        }

        
    }
}
