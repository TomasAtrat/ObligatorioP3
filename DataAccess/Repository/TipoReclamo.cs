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
    public class TipoReclamo
    {

        public TipoReclamo()
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


    }
}
