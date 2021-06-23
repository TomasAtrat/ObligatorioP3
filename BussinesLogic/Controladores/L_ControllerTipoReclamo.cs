using BussinesLogic.Interfaces;
using CommonSolution.Interfaces;
using CommonSolution.Dto;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controladores
{ 
    public class L_ControllerTipoReclamo : IControllersAbm 
    {
        public L_ControllerTipoReclamo()
        {
            this.repository = new Repository();
        }

        private Repository repository;

        public List<string> Alta(IDto dto)
        {
            List<string> errores = new List<string>();
            try
            {

                this.repository.TipoReclamoRepository.AddTipoReclamo((DtoTipoReclamo)dto);

            }catch(Exception ex)
            {
                errores.Add(ex.Message);
            }
            return errores;
        }

        public List<string> Baja(IDto dto)
        {
            List<string> errores = new List<string>();
            try
            {

                this.repository.TipoReclamoRepository.BajaTipoReclamo((DtoTipoReclamo)dto) ;

            }
            catch (Exception ex)
            {
                errores.Add(ex.Message);
            }
            return errores;
        }

        public List<string> Modificacion(IDto dto)
        {
            List<string> errores = new List<string>();
            try
            {

                this.repository.TipoReclamoRepository.ModificarTipoReclamo((DtoTipoReclamo)dto);

            }
            catch (Exception ex)
            {
                errores.Add(ex.Message);
            }
            return errores;
        }

        public List<IDto> ListAll()
        {
           return  this.repository.TipoReclamoRepository.ListarTipoReclamo().Cast<IDto>().ToList();
        }
    }
}
