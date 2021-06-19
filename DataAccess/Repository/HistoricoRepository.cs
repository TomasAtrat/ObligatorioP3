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
    public class HistoricoRepository
    {
        public HistoricoRepository()
        {
            this.historicoMapper = new HistoricoMapper();
        }

        private HistoricoMapper historicoMapper;

        public DtoHistoricoReclamo getElementById(long id)
        {
            DtoHistoricoReclamo dto = null;
            using (Context context = new Context())
            {
                dto = this.historicoMapper.mapToDto(context.t_HISTORICO_ESTADO_RECLAMO.AsNoTracking().FirstOrDefault(i => i.ID == id));
            }
            return dto;
        }

        public List<DtoHistoricoReclamo> getElements()
        {
            List<DtoHistoricoReclamo> colDtos = null;
            using (Context context= new Context())
            {
                colDtos = this.historicoMapper.mapToDto(context.t_HISTORICO_ESTADO_RECLAMO.AsNoTracking().ToList());
            }
            return colDtos;
        }
    }
}
