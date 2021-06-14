using CommonSolution.Dto;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ZonaRepository
    {
        public ZonaRepository()
        {

        }

        private ZonaMapper zonaMapper;

        public void AltaZona(DtoZona dto)
        {
            t_ZONA zona = this.zonaMapper.mapToEntity(dto);

            using (Context context= new Context())
            {
                using (DbContextTransaction tran= context.Database.BeginTransaction(IsolationLevel.ReadCommitted) )
                {
                    try
                    {
                        context.t_ZONA.Add(zona);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
        } //Validación try catch

        public void BajaZona(DtoZona dto)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction tran= context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_ZONA zona = context.t_ZONA.AsNoTracking().FirstOrDefault(i => i.ID == dto.id);
                        if (zona != null)
                            context.t_ZONA.Remove(zona);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                    
                }

            }
        }

        public void ModificarZona(DtoZona dto)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_ZONA zona = context.t_ZONA.AsNoTracking().FirstOrDefault(i => i.ID == dto.id);
                        zona.Nombre = dto.nombre;
                        zona.Color = dto.color;
                        zona.t_PUNTO = (ICollection<t_PUNTO>)dto.colPuntos;
                        zona.t_CUADRILLA_ZONA = (ICollection<t_CUADRILLA_ZONA>)dto.colCuadrillas;
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                    }
                }
            }
        }

        public DtoZona getElementById(long id)
        {
            DtoZona dto = null;
            using (Context context= new Context())
            {
                dto = this.zonaMapper.mapToDto(context.t_ZONA.AsNoTracking().FirstOrDefault(i => i.ID == id));
            }
            return dto;
        }

        public List<DtoZona> ListarZonas()
        {
            List<DtoZona> colZonas = new List<DtoZona>();
            using (Context context= new Context())
            {
                colZonas = this.zonaMapper.mapToDto(context.t_ZONA.AsNoTracking().ToList());
            }
            return colZonas;
        }
    }
}
