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

        public void AddPuntos(List<DtoPunto> punto)
        {
            using (Context cont = new Context())
            {
                using (DbContextTransaction tran = cont.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        foreach(DtoPunto p in  punto)
                        {
                            t_PUNTO puntoEntity = this.puntosMappers.mapToEntity(p);
                            cont.t_PUNTO.Add(puntoEntity);
                            cont.SaveChanges();
                            tran.Commit();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }
                }
            }
        }

    }
}
