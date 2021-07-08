using BussinesLogic.Interfaces;
using CommonSolution.Dto;
using CommonSolution.DTO;
using DataAccess.HTML_GENERATOR;
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
            this.reportes = new Reportes();
        }

        private Repository repository;
        private Reportes reportes;

        public List<DtoReclamo> getReclamosAsignadosPorCuadrilla(long idCuadrilla)
        {
            List<DtoReclamo> colDtos = this.repository.ReclamoRepository.getElements();
            return colDtos.Where(i => i.IDCuadrilla == idCuadrilla && (i.Estado.ToString() == "ASIGNADO" || i.Estado.ToString() == "EN_PROCESO")).ToList();
        }

        public List<DtoReclamosAtrasados> getReclamosAtrasados()
        {
            List<DtoReclamo> colDtos = this.repository.ReclamoRepository.getElements().Where(i => i.Estado.ToString() != "RESUELTO").ToList();
            List<DtoReclamosAtrasados> colReclamos = new List<DtoReclamosAtrasados>();
            foreach (DtoReclamo item in colDtos)
            {
                DtoReclamosAtrasados dto = new DtoReclamosAtrasados();
                dto.reclamo = item;
                dto.cantidadHorasRetraso = (int)Math.Round(((TimeSpan)(DateTime.Now - item.FechaHoraIngreso)).TotalHours);
                colReclamos.Add(dto);
            }
            colReclamos.OrderByDescending(i => i.cantidadHorasRetraso);
            return colReclamos;
        }

        public DtoCuadrilla mergePropertiesOFCuadrilla(long id)
        {
            DtoCuadrilla dto = this.repository.CuadrillaRepository.getElementById(id);
            List<DtoCuadrilla> colDtos = this.repository.CuadrillaRepository.getElements().Where(i => i.id == id).ToList();
            foreach (DtoCuadrilla item in colDtos)
            {
                foreach (DtoReclamo rec in item.colReclamos)
                {
                    dto.colReclamos.Add(rec);
                }
            }
            return dto;
        }

        public List<DtoCuadrilla> cuadrillasMasEficientes()
        {
            List<DtoCuadrilla> colDtos = this.repository.CuadrillaRepository.getCuadrillasFromView();
            foreach (DtoCuadrilla item in colDtos)
            {
                DtoCuadrilla dto = this.mergePropertiesOFCuadrilla(item.id);
                item.promedio = item.sumaHoras / dto.colReclamos.Count();
                item.nombre = dto.nombre;
                item.idZona = dto.idZona;
                item.Observaciones = dto.Observaciones;
                item.encargado = dto.encargado;
                item.idZona = dto.idZona;
                item.cantidadPeones = dto.cantidadPeones;
            }
            return colDtos;
        }

        public List<string> GenerarReporte(DtoReclamo dto)
        {
            List<string> colErrores = new List<string>();
            DtoReclamo reclamo = this.repository.ReclamoRepository.GetElementById(dto.ID);
            try
            {
                this.reportes.ReclamoReporte.GenerarReporte(reclamo, dto.directorio);
            }
            catch (Exception e)
            {
                colErrores.Add(e.Message);
            }
            return colErrores;
        }

        public string ToHtml(string folder, long id)
        {
            GeneradorHTML generador = new GeneradorHTML();
            return generador.GenerarHTML(folder, id);
        }
    }
}