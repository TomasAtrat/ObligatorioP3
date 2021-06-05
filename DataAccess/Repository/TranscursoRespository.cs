using CommonSolution.DTO;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TranscursoRespository
    {
        public TranscursoRespository()
        {
            this.transcursoMapper = new TranscursoMapper();
        }

        private TranscursoMapper transcursoMapper;

        public DtoTranscursoPartido getTranscurso(int idPartido)
        {
            DtoTranscursoPartido dto = null;
            using (DBEntities context= new DBEntities())
            {
                dto = this.transcursoMapper.mapToDto(context.TranscursoPartido.AsNoTracking().Where(i => i.idPartido == idPartido).OrderByDescending(o => o.nuTranscursoPartido).FirstOrDefault());
            }
            return dto;
        }
    }
}
