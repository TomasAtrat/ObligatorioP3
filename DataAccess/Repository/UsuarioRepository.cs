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
        }

        private UsuarioMapper usuarioMapper;

        public DtoUsuario getElementById(string nickname, string password)
        {
            t_USUARIO usuario = new t_USUARIO();
            using (Context context = new Context())
            {
                usuario = context.t_USUARIO.AsNoTracking().FirstOrDefault(i => i.NombreUsuario == nickname && i.Password == password);
            }
            return this.usuarioMapper.mapToDto(usuario);
        }

        public void AddUsuarioInBDD(DtoUsuario UsuarioNuevo)
        {


            using (Context context = new Context())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_USUARIO UsuarioAGuardar = this.usuarioMapper.mapToEntity(UsuarioNuevo);
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
                        user = this.usuarioMapper.mapToEntity(usuario);
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

    }
}
