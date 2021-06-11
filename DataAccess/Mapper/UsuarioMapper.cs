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
        public DtoUsuario mapToDto(t_USUARIO user)
        {
            DtoUsuario dto = new DtoUsuario();
            dto.Nombre = user.Nombre;
            dto.Apellido = user.Apellido;
            dto.Email = user.Email;
            dto.Telefono = user.Telefono;
            dto.EsFuncionario = user.EsFuncionario;
            dto.NombreUsuario = user.NombreUsuario;
            dto.Password = user.Password;
            //Llamar a mapper de reclamos
            return dto;
        }

        public List<DtoUsuario> mapToDto(List<t_USUARIO> users)
        {
            List<DtoUsuario> colDtos = new List<DtoUsuario>();
            if (users != null)
                users.ForEach(i => colDtos.Add(this.mapToDto(i)));
            return colDtos;
        }
    }
}
