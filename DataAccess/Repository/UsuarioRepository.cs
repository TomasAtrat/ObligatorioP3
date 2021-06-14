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
                usuario = context.t_USUARIO.AsNoTracking().FirstOrDefault(i => i.NombreUsuario == nickname && i.Password == password);
            }
            return this.usuarioMapper.MapToDto(usuario);
        }

        public void AddUsuarioInBDD(DtoUsuario UsuarioNuevo)
        {


            using (Context context = new Context())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_USUARIO UsuarioAGuardar = this.usuarioMapper.MapToEntity(UsuarioNuevo);
                        context.t_USUARIO.Add(UsuarioAGuardar);
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

        public void DeleteUsuario(string nickname, string password)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_USUARIO user = context.t_USUARIO.AsNoTracking().FirstOrDefault(f => f.NombreUsuario == nickname);
                        if (user != null)

                            context.t_USUARIO.Remove(user);
                        context.SaveChanges();
                        trann.Commit();
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
                        t_USUARIO user = context.t_USUARIO.FirstOrDefault(f => f.NombreUsuario == usuario.NombreUsuario);
                        user.Apellido = usuario.Apellido;
                        user.Nombre = usuario.Nombre;
                        user.NombreUsuario = usuario.NombreUsuario;
                        user.Password = usuario.Password;
                        user.Email = usuario.Email;
                        user.Telefono = usuario.Telefono;
                        user.EsFuncionario = usuario.EsFuncionario;
                        user.t_RECLAMO = this.reclamosMapeo.mapToListEntity(usuario.colReclamos);
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
                ListUsuarios = this.usuarioMapper.MapToListDto(context.t_USUARIO.ToList());
            }
            return ListUsuarios;
        }

    }
}
