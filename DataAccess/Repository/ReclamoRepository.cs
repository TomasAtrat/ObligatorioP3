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
    public class ReclamoRepository
    {
        public ReclamoRepository()
        {
            this.reclamoMapper = new ReclamoMapper();
        }

        private ReclamoMapper reclamoMapper;

        public void AltaReclamo(DtoReclamo dto)
        {
            t_RECLAMO reclamo = this.reclamoMapper.mapToEntity(dto);
            using (Context context= new Context())
            {
                using (DbContextTransaction tran= context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.t_RECLAMO.Add(reclamo);
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

        public void ModificarReclamo(DtoReclamo dto)
        {
            using (Context context= new Context())
            {
                using (DbContextTransaction tran= context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_RECLAMO reclamo = context.t_RECLAMO.AsNoTracking().FirstOrDefault(i => i.ID == dto.ID);
                        if (reclamo != null)
                        {
                            reclamo.IDCuadrilla = dto.IDCuadrilla;
                            reclamo.IDCuadrilla = dto.IDCuadrilla;
                            reclamo.IDTipoReclamo = dto.IDTipoReclamo;
                            reclamo.IDZona = dto.IDZona;
                            reclamo.Latitud = dto.Latitud;
                            reclamo.Longitud = dto.Longitud;
                            reclamo.Observaciones = dto.Observaciones;
                            reclamo.Estado = dto.Estado.ToString();
                            reclamo.FechaHoraIngreso = dto.FechaHoraIngreso;
                            reclamo.t_USUARIO = (ICollection<t_USUARIO>)dto.colUsuarios;
                            context.SaveChanges();
                            tran.Commit();
                        }
                        
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                }
            }
        }

        public void EliminarReclamo(DtoReclamo dto)
        {
            t_RECLAMO reclamo = this.reclamoMapper.mapToEntity(dto);
            using (Context context= new Context())
            {
                using (DbContextTransaction tran= context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.t_RECLAMO.Remove(reclamo);
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

        public DtoReclamo GetElementById(long id)
        {
            DtoReclamo dto = null;
            using (Context context = new Context())
            {
                dto = this.reclamoMapper.mapToDto(context.t_RECLAMO.AsNoTracking().FirstOrDefault(i => i.ID == id));
            }

            return dto;
        }

        public List<DtoReclamo> getElements()
        {
            List<DtoReclamo> colDtos = null;
            using (Context context= new Context())
            {
                colDtos = this.reclamoMapper.mapToDto(context.t_RECLAMO.AsNoTracking().Select(s=>s).ToList());
            }
            return colDtos;
        }

        public bool VerificarExistenica(long id)
        {
            bool existe = false;
            using (Context context= new Context())
            {
                existe = context.t_RECLAMO.AsNoTracking().Any(i => i.ID == id);
            }
            return existe;
        }
    }
}
