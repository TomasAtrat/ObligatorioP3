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
            }
            else if (dto.EsFuncionario)
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
            List<string> error = Validacion((DtoUsuario)dto);

            if (error.Count() == 0)
            {
                try
                {
                    this.repository.UsuarioRepository.AddUsuarioInBDD((DtoUsuario)dto);
                }
                catch (Exception ex)
                {
                    error.Add(ex.Message);
                }
            }
            return error;
        }

        public List<string> Baja(IDto dto)
        {
            List<string> errores = new List<string>();
            try
            {
                this.repository.UsuarioRepository.DeleteUsuario(((DtoUsuario)dto).NombreUsuario, ((DtoUsuario)dto).Password);

            }
            catch(Exception ex)
            {
               errores.Add(ex.Message);
            }
            return errores;
        }

        public List<string> Modificacion(IDto dto)
        {
            List<string> error = Validacion((DtoUsuario)dto);
            if (error.Count() == 0)
            {
                this.repository.UsuarioRepository.UpDateUser((DtoUsuario)dto);
            }
            return error;
        }

        public List<string> Validacion(DtoUsuario user)
        {
            List<string> errores = new List<string>();
            if (user.Nombre.Count() < 51 && user.Apellido.Count() < 51 && user.NombreUsuario.Count() < 51)
            {
                errores.Add("Verifique el largo de los datos");
            }
            if (user.Password.Count() < 51)
            {
                errores.Add("Password demasiado largo");
            }
            return errores;
        }
    }
}
