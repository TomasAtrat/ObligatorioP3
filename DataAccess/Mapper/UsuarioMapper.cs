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
        private ReclamosMapper reclamoMapeador;
        public DtoUsuario mapToDto(t_USUARIO user)
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
            dto.colReclamos = this.reclamoMapeador.mapToListEntity(user.t_RECLAMO.ToList());
            return dto;
        }

        public t_USUARIO mapToEntity(DtoUsuario usuarioAConvertir)
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

      
    }
}
