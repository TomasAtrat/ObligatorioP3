using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using DataAccess.Mapper;
using DataAccess.Model;
using CommonSolution.Dto;
using CommonSolution.Interfaces;

namespace DataAccess.Repository
{
    public class ReclamoRepository
    {
        public ReclamoRepository()
        {
            this.reclamoRepositorio = new ReclamoMapper();
            this.userMap = new UsuarioMapper();
            this.reclamoMapper = new ReclamoMapper();
        }

        private ReclamoMapper reclamoRepositorio;
        private UsuarioMapper userMap;
        private ReclamoMapper reclamoMapper;

        public bool VerificarExistenica(long id)
        {
            bool verif = false;
            using (Context context = new Context())
            {
                try
                {
                    verif = context.t_RECLAMO.AsNoTracking().Any(a => a.ID == id);
                }
                catch(Exception ex)
                {

                }
            }
            return verif;
        }
        public void AddReclamo(DtoReclamo dto)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.t_RECLAMO.Add(this.reclamoRepositorio.mapToEntity(dto));
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback(); 
                    }
                }
            }
        }

        public void DeleteReclamo(DtoReclamo dto)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_RECLAMO reclamo = context.t_RECLAMO.AsNoTracking().FirstOrDefault(i => i.ID == dto.ID);
                        if (reclamo != null)
                        {
                            context.t_RECLAMO.Remove(reclamo);
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

        public void UpDateReclamos(DtoReclamo dto)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction tann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try 
                    { 
                        t_RECLAMO reclamoAModificar = context.t_RECLAMO.FirstOrDefault(f => f.ID == dto.ID);
                        reclamoAModificar.IDZona = dto.IDZona;
                        reclamoAModificar.IDCuadrilla = dto.IDCuadrilla;
                        reclamoAModificar.IDTipoReclamo = dto.IDTipoReclamo;
                        reclamoAModificar.FechaHoraIngreso = dto.FechaHoraIngreso;
                        reclamoAModificar.Estado = dto.Estado.ToString();
                        reclamoAModificar.Observaciones = dto.Observaciones;
                        reclamoAModificar.Latitud = dto.Latitud;
                        reclamoAModificar.Longitud = dto.Longitud;
                        reclamoAModificar.t_USUARIO = this.userMap.MapToListEntity(dto.colUsuarios.ToList());
                        context.SaveChanges();
                        tann.Commit();
                    }
                    catch(Exception ex)
                    {
                        tann.Rollback();
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

        public List<IDto> EnlistarReclamos()
        {
            List<IDto> ListaDeReclamos = new List<IDto>();
            using (Context context = new Context())
            {
                ListaDeReclamos = this.reclamoRepositorio.mapToListDto(context.t_RECLAMO.ToList());
            }
            return ListaDeReclamos;
        }
    }
}
