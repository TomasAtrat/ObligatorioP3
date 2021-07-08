using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Mapper;
using CommonSolution.Dto;
using System.Data.Entity;
using System.Data;



namespace DataAccess.Repository
{
    public class Puntosrepository
    {
        private PuntoMapper puntosMappers;

        public Puntosrepository()
        {
            this.puntosMappers = new PuntoMapper();
        }

        public void AddPuntos(DtoPunto punto)
        {
            using (Context cont = new Context())
            {
                using (DbContextTransaction tran = cont.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        
                            t_PUNTO puntoEntity = this.puntosMappers.mapToEntity(punto);
                            cont.t_PUNTO.Add(puntoEntity);
                            cont.SaveChanges();
                            tran.Commit();
                        
                        
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }
                }
            }
        }

        public void UpDatePuntos(DtoPunto dto)
        {
            using (Context context = new Context())
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    { 
                    t_PUNTO punto = context.t_PUNTO.FirstOrDefault(f => f.ID == dto.id);
                    punto.IDZona = dto.idZona;
                    punto.Latitud = double.Parse(dto.lat);
                    punto.Longitud = double.Parse(dto.lng);
                    context.SaveChanges();
                    tran.Commit();
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                    }


                }
            }
        }

        public void DeletePunto(DtoPunto dto)
        {
            using (Context context = new Context())
            {
                t_PUNTO punt = context.t_PUNTO.FirstOrDefault(f => f.ID == dto.id);
                context.t_PUNTO.Remove(punt);
                context.SaveChanges();
            }
        }

        public bool SearchPunto(long dto)
        {
            bool exists = false;
            using (Context context = new Context())
            {
                exists = context.t_PUNTO.AsNoTracking().Any(a => a.ID == dto);
            }
            return exists;
        }

        public List<DtoPunto> getElements()
        {
            List<DtoPunto> dtoPuntos = new List<DtoPunto>();
            using (Context context = new Context())
            {
                dtoPuntos= this.puntosMappers.mapToDto(context.t_PUNTO.AsNoTracking().Select(i => i).ToList());
            }
            return dtoPuntos;
        }

      
    }
}
