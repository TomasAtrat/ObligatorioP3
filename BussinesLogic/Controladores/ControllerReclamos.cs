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
            if(error.Count() ==0 && (BuscarReclamoExistencia(((DtoReclamo)dto).ID) == false))
            {
                this.repositorio.ReclamoRepository.AddReclamo((DtoReclamo)dto);
            }
            throw new NotImplementedException();
        }

        public List<string> Baja(IDto dto)
        {
            List<string> errores = new List<string>();
            if(BuscarReclamoExistencia(((DtoReclamo)dto).ID) == true)
            { 
            this.repositorio.ReclamoRepository.DeleteReclamo((DtoReclamo)dto);
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
                this.repositorio.ReclamoRepository.UpDateReclamos((DtoReclamo)dto);
            }
            return errores;
        }

        public List<string> Verificacion(DtoReclamo rec)
        {
            List<string> errores = new List<string>();
            if(rec.Estado.ToString() != "PENDIENTE" && rec.Estado.ToString() != "ASIGNADO" &&
                rec.Estado.ToString() != "EN_PROCESO" && rec.Estado.ToString() != "RESUELTO" &&
                 rec.Estado.ToString() != "DESESTIMADO")
                {
                errores.Add("Estado incorrecto");
            }
           
            return errores;

        }

        public bool BuscarReclamoExistencia(long id)
        {
            return this.repositorio.ReclamoRepository.VerificarExistenica(id);
        }

      


    }
}
