using CommonSolution.Dto;
using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Repository
{
    public class TipoReclamoRepository
    {
        public TipoReclamoRepository()
        {
            this.TipoReclamoMapper = new TipoReclamoMapper();
        }

        private TipoReclamoMapper TipoReclamoMapper;

        public void AddTipoReclamo(DtoTipoReclamo dto)
        {
            t_TIPO_RECLAMO Treclamo = this.TipoReclamoMapper.maptoentity(dto);

            using (Context contex = new Context())
            {
                using (DbContextTransaction trann = contex.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        contex.t_TIPO_RECLAMO.Add(Treclamo);
                        contex.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception e)
                    {
                        trann.Rollback();
                        throw e;
                    }
                }

            }
        }
        public void BajaTipoReclamo(long id)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_TIPO_RECLAMO tiporeclamo = context.t_TIPO_RECLAMO.FirstOrDefault(i => i.ID == id);
                        if (tiporeclamo != null)
                        {
                            context.t_TIPO_RECLAMO.Remove(tiporeclamo);
                            context.SaveChanges();
                            tran.Commit();
                        }
                    }
                    catch (Exception exce)
                    {
                        tran.Rollback();
                    }

                }

            }
        }
        public void ModificarTipoReclamo(DtoTipoReclamo dto)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_TIPO_RECLAMO tiporeclamo = context.t_TIPO_RECLAMO.FirstOrDefault(i => i.ID == dto.id);

                        tiporeclamo.Nombre = dto.nombre;
                        tiporeclamo.Descripcion = dto.descripcion;

                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception exce)
                    {
                        tran.Rollback();
                        throw exce;
                    }
                }
            }
        }
        public DtoTipoReclamo getElementByIdTipoReclamo(long id)
        {
            DtoTipoReclamo dto = null;
            using (Context context = new Context())
            {
                dto = this.TipoReclamoMapper.mapToDto(context.t_TIPO_RECLAMO.AsNoTracking().FirstOrDefault(i => i.ID == id));
            }
            return dto;


        }
        public bool ExisteTipoReclamo(long id)
        {
            bool existe = false;
            using (Context context = new Context())
            {
                existe = context.t_TIPO_RECLAMO.AsNoTracking().Any(a => a.ID == id);
            }
            return existe;
        }
        public List<DtoTipoReclamo> ListarTipoReclamo()
        {
            List<DtoTipoReclamo> tiporeclamo = new List<DtoTipoReclamo>();
            using (Context context = new Context())
            {
                List<t_TIPO_RECLAMO> entity = context.t_TIPO_RECLAMO.Select(s => s).ToList();
                tiporeclamo = this.TipoReclamoMapper.maptoListDto(entity);
            }
            return tiporeclamo;
        }
    }
}