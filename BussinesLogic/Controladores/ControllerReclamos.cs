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
            List<string> error = Verificacion((DtoReclamo)dto);
            if(error.Count() ==0)
            {
                long idZona= AsignarCuadrilla((DtoReclamo)dto); //Asignación por referencia
                ((DtoReclamo)dto).IDZona = idZona.ToString();
                dto = this.repositorio.ReclamoRepository.AltaReclamo((DtoReclamo)dto);
            }
            return error;
        }

        private long AsignarCuadrilla(DtoReclamo dto)
        {
            DtoCuadrilla dtoCuad = new DtoCuadrilla();

            if (long.Parse(dto.IDZona) == -1)
            {
                dtoCuad = this.repositorio.CuadrillaRepository.getElements().OrderBy(i => i.colReclamos.Count).First();
            }
            else
            {
                List<DtoCuadrilla> cuadrillas = this.repositorio.CuadrillaRepository.getCuadrillasByZona(long.Parse(dto.IDZona)).OrderBy(i => i.colReclamos.Count).ToList(); 
                if(cuadrillas == null || cuadrillas.Count==0)
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

        public List<string> Baja(IDto dto)
        {
            List<string> errores = new List<string>();
            bool existe = this.repositorio.ReclamoRepository.VerificarExistenica(((DtoReclamo)dto).ID);

            if(existe)
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
            List<string> errores = Verificacion((DtoReclamo)dto);
            if(errores.Count() == 0)
            {
                this.repositorio.ReclamoRepository.ModificarReclamo((DtoReclamo)dto);
            }
            return errores;
        }

        public List<string> Verificacion(DtoReclamo rec)
        {
            List<string> errores = new List<string>();
            //if(rec.Estado.ToString() != "PENDIENTE" && rec.Estado.ToString() != "ASIGNADO" &&
            //    rec.Estado.ToString() != "EN_PROCESO" && rec.Estado.ToString() != "RESUELTO" &&
            //     rec.Estado.ToString() != "DESESTIMADO")
            //    {
            //    errores.Add("Estado incorrecto");
            //}
           
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

    }
}
