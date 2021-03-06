using CommonSolution.Dto;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;

namespace DataAccess.Repository
{
    public class UsuarioRepository
    {
        public UsuarioRepository()
        {
            this.usuarioMapper = new UsuarioMapper();
            this.reclamosMapeo = new ReclamoMapper();
        }

        private UsuarioMapper usuarioMapper;
        private ReclamoMapper reclamosMapeo;

        public DtoUsuario getElementById(string nickname, string password)
        {
            t_USUARIO usuario = new t_USUARIO();
            using (Context context = new Context())
            {
                usuario = context.t_USUARIO.AsNoTracking().FirstOrDefault(i => i.NombreUsuario == nickname && i.Password == password && i.Estado == true);
            }

            if(usuario!=null)
                return this.usuarioMapper.MapToDto(usuario);

            return null;
        }

        public void AddUsuarioInBDD(DtoUsuario Dtousuario)
        {
            t_USUARIO NuevoUsuario = this.usuarioMapper.MapToEntity(Dtousuario);

            using (Context Context = new Context())
            {
                using (DbContextTransaction trann = Context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        NuevoUsuario.Estado = true;
                        Context.t_USUARIO.Add(NuevoUsuario);
                        Context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }


            }
        }


        public void DeleteUsuario(string nickname, string password)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_USUARIO user = context.t_USUARIO.FirstOrDefault(f => f.NombreUsuario == nickname && f.Password == password);
                        if (user != null)
                        {
                            user.Estado = false;

                            context.SaveChanges();
                            trann.Commit();
                        }
                    }
                    catch (Exception exce)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

        public void UpDateUser(DtoUsuario usuario)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_USUARIO user = context.t_USUARIO.FirstOrDefault(f => f.NombreUsuario == usuario.NombreUsuario && f.Password == usuario.Password);
                        user.Apellido = usuario.Apellido;
                        user.Nombre = usuario.Nombre;
                        user.Password = usuario.Password;
                        user.Telefono = usuario.Telefono;
                        // user.t_RECLAMO = this.reclamosMapeo.mapToListDto(usuario.colReclamos);
                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

        public List<DtoUsuario> ListarUsuarios()
        {
            List<DtoUsuario> ListUsuarios = new List<DtoUsuario>();
            using (Context context = new Context())
            {
                ListUsuarios = this.usuarioMapper.MapToListDto(context.t_USUARIO.Where(s => s.Estado == true).ToList());
            }
            return ListUsuarios;
        }

        public bool ValidarNombre(string userName)
        {
            bool existe;
            using (Context context= new Context())
            {
                existe = context.t_USUARIO.Any(i => i.NombreUsuario == userName);
            }
            return existe;
        }

        public DtoUsuario getUserByMail(string mail)
        {
            t_USUARIO user = new t_USUARIO();
            using (Context context=new Context())
            {
                user = context.t_USUARIO.AsNoTracking().FirstOrDefault(i => i.Email == mail);
            }
            if (user != null)
                return this.usuarioMapper.MapToDto(user);
            return null;
        }

        public bool ValidarMail(string mail)
        {
            bool existe;
            using (Context context= new Context())
            {
                existe = context.t_USUARIO.Any(i => i.Email == mail);
            }
            return existe;
        }
    }
}
