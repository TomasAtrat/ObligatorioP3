using BussinesLogic.Interfaces;
using CommonSolution.Dto;
using CommonSolution.DTO;
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

        public List<DtoReclamosAtrasados> getReclamosAtrasados()
        {
            List<DtoReclamo> colDtos = this.repository.ReclamoRepository.getElements().Where(i => i.Estado.ToString() == "PENDIENTE").ToList();
            List<DtoReclamosAtrasados> colReclamos = new List<DtoReclamosAtrasados>();
            foreach (DtoReclamo item in colDtos)
            {
                DtoReclamosAtrasados dto = new DtoReclamosAtrasados();
                dto.reclamo = item;
                double valor = ((TimeSpan)(DateTime.Now - item.FechaHoraIngreso)).TotalHours;
                dto.cantidadHorasRetraso = Math.Round(valor);
                colReclamos.Add(dto);
            }
            colReclamos.OrderByDescending(d =>d.cantidadHorasRetraso);
            return colReclamos;
        }
    }
}