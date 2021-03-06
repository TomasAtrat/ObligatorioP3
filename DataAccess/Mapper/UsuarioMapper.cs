using CommonSolution.Dto;
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
            dto.Estado = user.Estado;
           // dto.colReclamos = this.reclamoMapeador.mapToDto(user.t_RECLAMO.ToList());
            return dto;
        }

        public t_USUARIO MapToEntity(DtoUsuario usuarioAConvertir)
        {
            t_USUARIO UsuarioConv = new t_USUARIO();
           UsuarioConv.NombreUsuario = usuarioAConvertir.NombreUsuario;
           UsuarioConv.Password = usuarioAConvertir.Password;
           UsuarioConv.Nombre = usuarioAConvertir.Nombre;
           UsuarioConv.Apellido = usuarioAConvertir.Apellido;
           UsuarioConv.Email = usuarioAConvertir.Email;
           UsuarioConv.Telefono = usuarioAConvertir.Telefono;
            UsuarioConv.EsFuncionario = usuarioAConvertir.EsFuncionario;
            UsuarioConv.Estado = usuarioAConvertir.Estado;
            return UsuarioConv;

        }

      

        public List<DtoUsuario> MapToListDto(List<t_USUARIO> users)
        {
            List<DtoUsuario> colDtos = new List<DtoUsuario>();
            if (users != null)
                users.ForEach(i => colDtos.Add(this.MapToDto(i)));
            return colDtos;
        }

        public List<t_USUARIO> MapToListEntity(List<DtoUsuario> users)
        {
            List<t_USUARIO> colDtos = new List<t_USUARIO>();
            if (users != null)
                users.ForEach(i => colDtos.Add(this.MapToEntity(i)));
            return colDtos;
        }
    }
}
