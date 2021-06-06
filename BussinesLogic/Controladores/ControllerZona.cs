using BussinesLogic.Interfaces;
using CommonSolution.Dto;
using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controladores
{
    class ControllerZona : IControllers
    {
        public List<string> Alta(IDto dto)
        {
            List<string> colErrores = this.Validate((DtoZona)dto);

            return colErrores;
        }

        public List<string> Baja(IDto dto)
        {
            throw new NotImplementedException();
        }

        public List<IDto> Listado()
        {
            throw new NotImplementedException();
        }

        public List<string> Modificacion(IDto dto)
        {
            throw new NotImplementedException();
        }

        private List<string> Validate(DtoZona dto)
        {
            List<string> colErrores = new List<string>();

            return colErrores;
        }
    }
}
