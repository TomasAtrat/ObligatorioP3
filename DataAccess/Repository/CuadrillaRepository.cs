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
    public class CuadrillaRepository
    {
        public CuadrillaRepository()
        {
            this.cuadrillaMapper = new CuadrillaMapper();
        }

        private CuadrillaMapper cuadrillaMapper;

        public void AltaCuadrilla(DtoCuadrilla dto)
        {

            t_CUADRILLA cuadrilla = this.cuadrillaMapper.maptoentity(dto);

            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        cuadrilla.Estado = true;
                        context.t_CUADRILLA.Add(cuadrilla);
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
        }
        public void BajaCuadrilla(DtoCuadrilla dto)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {

                        t_CUADRILLA cuadrilla = context.t_CUADRILLA.FirstOrDefault(i => i.ID == dto.id);
                        if (cuadrilla != null)

                            cuadrilla.Estado = false;

                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch (Exception exce)
                    {
                        tran.Rollback();
                    }

                }

            }
        }
        public void ModificarCuadrilla(DtoCuadrilla dto)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        t_CUADRILLA cuadrilla = context.t_CUADRILLA.FirstOrDefault(i => i.ID == dto.id);
                        cuadrilla.Nombre = dto.nombre;
                        cuadrilla.CantidadPeones = (short)dto.cantidadPeones;
                        cuadrilla.Encargado = dto.encargado;

                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception exce)
                    {
                        tran.Rollback();
                    }
                }
            }
        }
        public DtoCuadrilla getElementById(long id)
        {
            DtoCuadrilla dto = null;
            using (Context context = new Context())
            {
                dto = this.cuadrillaMapper.mapToDto(context.t_CUADRILLA.AsNoTracking().FirstOrDefault(i => i.ID == id));
            }
            return dto;
        }
        public bool ExisteCuadrilla(long id)
        {
            bool existe = false;
            using (Context context = new Context())
            {
                existe = context.t_CUADRILLA.AsNoTracking().Any(a => a.ID == id);
            }
            return existe;
        }

        public List<DtoCuadrilla> ListarCuadrilla()
        {
            List<DtoCuadrilla> colCuadrillas = new List<DtoCuadrilla>();
            using (Context context = new Context())
            {
                colCuadrillas = this.cuadrillaMapper.maptoDto(context.t_CUADRILLA.AsNoTracking().Where(s => s.Estado == true).ToList());
            }
            return colCuadrillas;
        }

        public List<DtoCuadrilla> getCuadrillasByZona(long idZona)
        {
            List<DtoCuadrilla> colCuadrillas = new List<DtoCuadrilla>();
            using (Context context = new Context())
            {
                colCuadrillas = this.cuadrillaMapper.mapToDto(context.t_CUADRILLA_ZONA.AsNoTracking().Where(i => i.IDZona == idZona).ToList());
            }
            return colCuadrillas;
        }

        public void AltaCuadrillaZona(DtoCuadrilla dto)
        {
            t_CUADRILLA_ZONA entity = this.cuadrillaMapper.mapToEntity(dto);
            using (Context context= new Context())
            {
                using (DbContextTransaction tran= context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.t_CUADRILLA_ZONA.Add(entity);
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
        }

    }
}
