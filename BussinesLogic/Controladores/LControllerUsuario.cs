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
    public class LControllerUsuario : IControllers
    {
        public LControllerUsuario()
        {
            this.repository = new Repository();
        }

        private Repository repository;

        public List<string> Alta(IDto dto)
        {
            List<string> error = new List<string>();

            try
            {
                this.repository.UsuarioRepository.AddUsuarioInBDD((DtoUsuario)dto);
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
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
            catch (Exception ex)
            {
                errores.Add(ex.Message);
            }
            return errores;
        }

        public List<string> Modificacion(IDto dto)
        {
            List<string> error = new List<string>();

            this.repository.UsuarioRepository.UpDateUser((DtoUsuario)dto);

            return error;
        }

        public List<IDto> ListAll()
        {
            return this.repository.UsuarioRepository.ListarUsuarios().Cast<IDto>().ToList();
        }


        public List<DtoUsuario> ListarFuncionarios()
        {
            List<DtoUsuario> dtoUsuarios = this.repository.UsuarioRepository.ListarUsuarios();
            return dtoUsuarios.Where(i => i.EsFuncionario == true).ToList();

        }

        public List<DtoUsuario> ListarUsuarios()
        {
            List<DtoUsuario> dtoUsuarios = this.repository.UsuarioRepository.ListarUsuarios();
            return dtoUsuarios.Where(i => i.EsFuncionario == false).ToList();

        }

        public List<IDto> add(IDto dto)
        {
            throw new NotImplementedException();
        }

        public DtoUsuario ExtraerUsuaroFuncionario(DtoUsuario dto)
        {
            return this.repository.UsuarioRepository.getElementById(dto.NombreUsuario, dto.Password);
        }

        public DtoUsuario ExtraerPorNyP(string nombre, string paswword)
        {
            return this.repository.UsuarioRepository.getElementById(nombre, paswword);
        }

        public bool ValidarNombre(string nombreUsuario)
        {
            return this.repository.UsuarioRepository.ValidarNombre(nombreUsuario);
        }

        public DtoUsuario getUserByMail(string mail)
        {
            return this.repository.UsuarioRepository.getUserByMail(mail);
        }

        public bool ValidarMail(string mail)
        {
            return this.repository.UsuarioRepository.ValidarMail(mail);
        }
    }
}
