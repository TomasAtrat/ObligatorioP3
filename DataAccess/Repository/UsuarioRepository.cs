using CommonSolution.Dto;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UsuarioRepository
    {
        public UsuarioRepository()
        {
            this.usuarioMapper = new UsuarioMapper();
        }

        private UsuarioMapper usuarioMapper;

        public DtoUsuario getElementById(string nickname, string password) 
        {
            t_USUARIO usuario = new t_USUARIO();
            using (Context context= new Context())
            {
                usuario = context.t_USUARIO.AsNoTracking().FirstOrDefault(i => i.NombreUsuario == nickname && i.Password == password);
            }
            return this.usuarioMapper.mapToDto(usuario);
        }
         
    }
}
