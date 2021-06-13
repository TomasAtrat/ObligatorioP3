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
    public class ControllerCuadrilla : IControllers
    {
        public ControllerCuadrilla()
        {
            this.repository = new Repository();
        }

        private Repository repository;

        public List<string> Alta(IDto dto)
        {
            List<string> colErrores = this.Validate((DtoCuadrilla)dto);
            if (colErrores.Count == 0)
            {
                try
                {
                    this.repository.CuadrillaRepository.AltaCuadrilla((DtoCuadrilla)dto);
                }
                catch (Exception exec)
                {
                    colErrores.Add(exec.Message);
                }
            }
            return colErrores;
        }

        public List<string> Baja(IDto dto)
        {
            List<string> colErrores = new List<string>();

            this.repository.CuadrillaRepository.BajaCuadrilla((DtoCuadrilla)dto);
            return colErrores;
        }
        public List<string> Modificacion(IDto dto)
        {
            List<string> colErrores = new List<string>();
            this.repository.CuadrillaRepository.ModificarCuadrilla((DtoCuadrilla)dto);
            return colErrores;
        }

        public List<DtoCuadrilla> Listado()
        {
            return this.repository.CuadrillaRepository.ListarCuadrilla();
        }


        private List<string> Validate(DtoCuadrilla dto)
        {
            List<string> colErrores = new List<string>();

            return colErrores;
        }
    }
}
