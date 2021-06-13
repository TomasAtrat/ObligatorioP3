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

        public void AddReclamo(DtoTipoReclamo dto)
        {
            using (Context contex = new Context())
            { 
            
            
            }
        }


    }
}
