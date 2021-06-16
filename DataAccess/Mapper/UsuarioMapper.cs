using CommonSolution.Dto;
using CommonSolution.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Mapper
{
    public class UsuarioMapper
    {
        private ReclamoMapper reclamoMapeador;
        public DtoUsuario MapToDto(t_USUARIO user)
        {
            DtoUsuario dto = new DtoUsuario();
            DtoReclamo dtoHelp = new DtoReclamo();
            dto.Nombre = user.Nombre;
            dto.Apellido = user.Apellido;
            dto.Email = user.Email;
            dto.Telefono = user.Telefono;
            dto.EsFuncionario = user.EsFuncionario;
            dto.NombreUsuario = user.NombreUsuario;
            dto.Password = user.Password;
            dto.colReclamos = this.reclamoMapeador.mapToListDtoB(user.t_RECLAMO.ToList());
            return dto;
        }

        public t_USUARIO MapToEntity(DtoUsuario usuarioAConvertir)
        {
            t_USUARIO UsuarioConv = new t_USUARIO();
            usuarioAConvertir.NombreUsuario = UsuarioConv.NombreUsuario;
            usuarioAConvertir.Password = UsuarioConv.Password;
            usuarioAConvertir.Nombre = UsuarioConv.Nombre;
            usuarioAConvertir.Apellido = UsuarioConv.Apellido;
            usuarioAConvertir.Email = UsuarioConv.Email;
            usuarioAConvertir.Telefono = UsuarioConv.Telefono;
            usuarioAConvertir.EsFuncionario = UsuarioConv.EsFuncionario;
            return UsuarioConv;

        }

      

        public List<IDto> MapToListDto(List<t_USUARIO> users)
        {
            List<IDto> colDtos = new List<IDto>();
            if (users != null)
                users.ForEach(i => colDtos.Add(this.MapToDto(i)));
            return colDtos;
        }

        public List<t_USUARIO> MapToListDTO(List<DtoUsuario> users)
        {
            List<t_USUARIO> colDtos = new List<t_USUARIO>();
            if (users != null)
                users.ForEach(i => colDtos.Add(this.MapToEntity(i)));
            return colDtos;
        }

        public List<DtoUsuario> MapToListEntity(List<t_USUARIO> users)
        {
            List<DtoUsuario> colDtos = new List<DtoUsuario>();
            if (users != null)
                users.ForEach(i => colDtos.Add(this.MapToDto(i)));
            return colDtos;
        }
    }
}
