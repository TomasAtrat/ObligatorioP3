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
            this.cuadrillaMapper = new CuadrillaMapper();
        }

        private ReclamoMapper reclamoMapper;
        private CuadrillaMapper cuadrillaMapper;

        public DtoReclamo AltaReclamo(DtoReclamo dto)
        {
            t_RECLAMO reclamo = this.reclamoMapper.mapToEntity(dto);
            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        reclamo.FechaHoraIngreso = DateTime.Now;
                        reclamo.EstadoL = true; //Habilitado
                        context.t_RECLAMO.Add(reclamo);
                        context.SaveChanges();
                        dto = this.reclamoMapper.mapToDto(reclamo);
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                    }
                }
            }
            return dto;
        }

        public void ModificarReclamo(DtoReclamo dto)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_RECLAMO reclamo = context.t_RECLAMO.FirstOrDefault(i => i.ID == dto.ID);

                        reclamo.IDCuadrilla = dto.IDCuadrilla;
                        reclamo.IDTipoReclamo = dto.IDTipoReclamo;
                        reclamo.IDZona = long.Parse(dto.IDZona);
                        reclamo.Latitud =dto.Latitud;
                        reclamo.Longitud = dto.Longitud;
                        reclamo.Observaciones = dto.Observaciones;
                        reclamo.Estado = dto.Estado.ToString();
                        reclamo.FechaHoraIngreso = dto.FechaHoraIngreso;
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

        public void EliminarReclamo(DtoReclamo dto)
        {
            t_RECLAMO reclamo = this.reclamoMapper.mapToEntity(dto);
            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_RECLAMO reclamoB = context.t_RECLAMO.FirstOrDefault(f => f.ID == dto.ID);
                        reclamoB.EstadoL = false;
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
            using (Context context = new Context())
            {
                colDtos = this.reclamoMapper.mapToDto(context.t_RECLAMO.AsNoTracking().Where(s => s.EstadoL == true).ToList());
            }
            return colDtos;
        }

        public bool VerificarExistenica(long id)
        {
            bool existe = false;
            using (Context context = new Context())
            {
                existe = context.t_RECLAMO.AsNoTracking().Any(i => i.ID == id);
            }
            return existe;
        }

        public List<DtoReclamo> ListarPorEstado(string estado)
        {
            List<DtoReclamo> colReclamos = new List<DtoReclamo>();
            using (Context context= new Context())
            {
                colReclamos = this.reclamoMapper.mapToDto(context.t_RECLAMO.AsNoTracking().Where(i => i.Estado == estado).ToList());
            }
            return colReclamos;
        }
    }  
}
