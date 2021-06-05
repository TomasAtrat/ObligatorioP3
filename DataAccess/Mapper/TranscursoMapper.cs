using CommonSolution.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TranscursoMapper
    {
        public TranscursoPartido mapToEntity(DtoTranscursoPartido dto)
        {
            TranscursoPartido en = new TranscursoPartido();
            en.idPartido = dto.idPartido;
            en.nuOrdenPartido = dto.nuOrdenPartido;
            en.nuTranscursoPartido = dto.nuTranscursoPartido;
            en.puntoJugador1 = dto.puntoJugador1;
            en.puntoJugador2 = dto.puntoJugador2;
            return en;
        }

        public DtoTranscursoPartido mapToDto(TranscursoPartido tran)
        {
            DtoTranscursoPartido en = new DtoTranscursoPartido();
            en.idPartido = tran.idPartido;
            en.nuOrdenPartido = tran.nuOrdenPartido;
            en.nuTranscursoPartido = tran.nuTranscursoPartido;
            en.puntoJugador1 = tran.puntoJugador1;
            en.puntoJugador2 = tran.puntoJugador2;
            return en;
        }
    }
}
