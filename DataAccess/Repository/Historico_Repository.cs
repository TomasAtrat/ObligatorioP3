using CommonSolution.Dto;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Historico_Repository
    {
        public Historico_Repository()
        {
            this.historico_Mapper = new Historico_Mapper();
        }

        private Historico_Mapper historico_Mapper;


        public List<DtoHistoricoReclamo> getElements()
        {
            List<DtoHistoricoReclamo> colDtos = new List<DtoHistoricoReclamo>();
            using (Context context= new Context())
            {
                colDtos = this.historico_Mapper.mapToDto(context.t_HISTORICO_ESTADO_RECLAMO.AsNoTracking().ToList());
            }
            return colDtos;
        }

        public List<DtoHistoricoReclamo> getElementsByFK(long idReclamo)
        {
            List<DtoHistoricoReclamo> colDtos = new List<DtoHistoricoReclamo>();
            using (Context context = new Context())
            {
                colDtos = this.historico_Mapper.mapToDto(context.t_HISTORICO_ESTADO_RECLAMO.AsNoTracking().Where(i=>i.IDReclamo==idReclamo).ToList());
            }
            return colDtos;
        }
    }
}
