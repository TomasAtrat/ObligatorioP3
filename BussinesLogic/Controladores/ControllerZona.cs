using BussinesLogic.Interfaces;
using CommonSolution.Dto;
using CommonSolution.Interfaces;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controladores
{
    public class ControllerZona : IControllersAbm  , IControllersListado
    {

        public ControllerZona()
        {
            this.repository = new Repository();
        }

        private Repository repository;

        public List<string> Alta(IDto dto)
        {
            List<string> colErrores = this.Validate((DtoZona)dto);
            if (colErrores.Count == 0)
            {
                try
                {
                    this.repository.ZonaRepository.AltaZona((DtoZona)dto);
                }
                catch (Exception e)
                {
                    colErrores.Add(e.Message);
                }
            }
            return colErrores;
        }

        public List<string> Baja(IDto dto)
        {
            List<string> colErrores = new List<string>();
            //Primero hay que eliminar todos los puntos en la tabla de puntos asociados a dicho id
            this.repository.ZonaRepository.BajaZona((DtoZona)dto);
            return colErrores;
        }

        public List<IDto> ListAll()
        {
            return this.repository.ZonaRepository.ListarZonas().Cast<IDto>().ToList();
        }

        public List<string> Modificacion(IDto dto)
        {
            List<string> colErrores = new List<string>();
            this.repository.ZonaRepository.ModificarZona((DtoZona)dto);
            return colErrores;
        }

        private List<string> Validate(DtoZona dto)
        {
            List<string> colErrores = new List<string>();

            return colErrores;
        }

        public void listar(IDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
