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
    public class ControllerUsuario : IControllers
    {
        public ControllerUsuario()
        {
            this.repository = new Repository();
        }

        private Repository repository;


        public string existeCuenta(string nickname, string password) 
        {
            string url = "";
            DtoUsuario dto = this.repository.UsuarioRepository.getElementById(nickname, password);
            if (dto == null)
            {
                url = "";
            }else if (dto.EsFuncionario)
            {
                url = "";
            }
            else
            {
                url = "";
            }
            return url;
        }

        public List<string> Alta(IDto dto)
        {
            DtoUsuario dto = this.repository.UsuarioRepository.
        }

        public List<string> Baja(IDto dto)
        {
            throw new NotImplementedException();
        }

        public List<string> Modificacion(IDto dto)
        {
            throw new NotImplementedException();
        }

    }
}
