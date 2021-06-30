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
                long idCuadrilla= AsignarCuadrilla((DtoReclamo)dto); //Asignación por referencia
                dto= this.repositorio.ReclamoRepository.AltaReclamo((DtoReclamo)dto);
                DtoCuadrilla dtoCuad= this.repositorio.CuadrillaRepository.getElementById(idCuadrilla);//Obtener cuadrilla
                dtoCuad.colReclamos.Add((DtoReclamo)dto); //Añadir dto al colReclamos de la lista para siguiente asignación de cuadrilla
                this.repositorio.CuadrillaRepository.ModificarCuadrilla(dtoCuad); //Comittear la modificación
            }
            return error;
        }

        private long AsignarCuadrilla(DtoReclamo dto)
        {
            DtoCuadrilla dtoCuadrilla = this.repositorio.CuadrillaRepository.getCuadrillasByZona(long.Parse(dto.IDZona)).OrderBy(i=>i.colReclamos.Count).First(); //Asigna la cuadrilla de una manera balanceada
            dto.IDCuadrilla = dtoCuadrilla.id;
            return dtoCuadrilla.id;
        }

        public List<string> Baja(IDto dto)
        {
            List<string> errores = new List<string>();
            if(BuscarReclamoExistencia(((DtoReclamo)dto).ID) == true)
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
            if(errores.Count() == 0 && BuscarReclamoExistencia(((DtoReclamo)dto).ID) == true)
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

        public bool BuscarReclamoExistencia(long id) //No se puede comparar si un reclamo ya existe porque el id es asignado automáticamente, y al momento el id del dto es null
        {
            return this.repositorio.ReclamoRepository.VerificarExistenica(id);
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

    }
}
