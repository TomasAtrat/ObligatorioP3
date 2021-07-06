using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Persistencia;
using CommonSolution.Dto;
using BussinesLogic.Interfaces;
using CommonSolution.Interfaces;

namespace BussinesLogic.Controladores
{
    public class ControllerReclamos : IControllers
    {
        private Repository repositorio;
        public ControllerReclamos()
        {
            this.repositorio = new Repository();
        }


        public List<string> Alta(IDto dto)
        {
            List<string> error = new List<string>();

            long idZona = AsignarCuadrilla((DtoReclamo)dto); //Asignación por referencia
            ((DtoReclamo)dto).IDZona = idZona.ToString();
            ((DtoReclamo)dto).Estado = Estado.ASIGNADO;
            dto = this.repositorio.ReclamoRepository.AltaReclamo((DtoReclamo)dto);

            return error;
        }

        private long AsignarCuadrilla(DtoReclamo dto)
        {
            DtoCuadrilla dtoCuad = new DtoCuadrilla();
            if (this.repositorio.CuadrillaRepository.getElements().Count > 0)
            {
                if (long.Parse(dto.IDZona) == -1)
                {
                    dtoCuad = this.repositorio.CuadrillaRepository.getElements().OrderBy(i => i.colReclamos.Count).First();
                }
                else
                {
                    List<DtoCuadrilla> cuadrillas = this.repositorio.CuadrillaRepository.getCuadrillasByZona(long.Parse(dto.IDZona)).OrderBy(i => i.colReclamos.Count).ToList();
                    if (cuadrillas == null || cuadrillas.Count == 0)
                    {
                        dtoCuad = this.repositorio.CuadrillaRepository.getElements().OrderBy(i => i.colReclamos.Count).First();
                    }
                    else
                    {
                        dtoCuad = cuadrillas.First();  //Asigna la cuadrilla de una manera balanceada  
                    }
                }

                dto.IDCuadrilla = dtoCuad.id;
                return dtoCuad.idZona;
            }

            return -1;
        }

        public List<string> Baja(IDto dto)
        {
            List<string> errores = new List<string>();
            bool existe = this.repositorio.ReclamoRepository.VerificarExistenica(((DtoReclamo)dto).ID);

            if (existe)
            {
                this.repositorio.ReclamoRepository.EliminarReclamo((DtoReclamo)dto);
            }
            else
            {
                errores.Add("No se puede eliminar elementos inexistentes");
            }
            return errores;
        }

        public List<string> Modificacion(IDto dto)
        {
            List<string> errores = new List<string>();

            this.repositorio.ReclamoRepository.ModificarReclamo((DtoReclamo)dto);

            return errores;
        }

        public List<IDto> ListAll()
        {
            return this.repositorio.ReclamoRepository.getElements().Cast<IDto>().ToList();
        }

        public void CambiarEstadoReclamo(DtoReclamo dto)
        {
            DtoReclamo reclamo = this.repositorio.ReclamoRepository.GetElementById(dto.ID);
            reclamo.Estado = dto.Estado;
            this.repositorio.ReclamoRepository.ModificarReclamo(reclamo);
        }

        public DtoReclamo getElementById(long id)
        {
            return this.repositorio.ReclamoRepository.GetElementById(id);
        }

        public List<DtoHistoricoReclamo> VerHistorico(long idReclamo)
        {
            return this.repositorio.Historico_Repository.getElementsByFK(idReclamo);
        }

        public List<DtoHistoricoReclamo> VerHistorico()
        {
            return this.repositorio.Historico_Repository.getElements();
        }

        public void ActualizarHistorico(DtoHistoricoReclamo dto)
        {
            this.repositorio.Historico_Repository.Actualizar(dto);
        }
    }
}