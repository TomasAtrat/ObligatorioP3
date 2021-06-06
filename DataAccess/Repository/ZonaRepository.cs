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
        }
    }
}
