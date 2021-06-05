using CommonSolution.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    class PartidoMapper
    {
        public DtoPartido mapToDto(Partido entity)
        {
            DtoPartido dto = new DtoPartido();
            dto.FechaHoraFin = entity.FechaHoraFin;
            dto.FechaHoraInicio = entity.FechaHoraInicio;
            dto.idJugador1 = entity.idJugador1;
            dto.idJugador2 = entity.idJugador2;
            dto.idPartido = entity.idPartido;
            dto.idTorneo = entity.idTorneo;
            dto.PuntosJugador1 = entity.PuntosJugador1;
            dto.PuntosJugador2 = entity.PuntosJugador2;
            return dto;
        }

        public Partido mapToEntity(DtoPartido dto)
        {
            Partido entity = new Partido();
            entity.FechaHoraFin = dto.FechaHoraFin;
            entity.FechaHoraInicio = dto.FechaHoraInicio;
            entity.idJugador1 = dto.idJugador1;
            entity.idJugador2 = dto.idJugador2;
            entity.idPartido = dto.idPartido;
            entity.idTorneo = dto.idTorneo;
            entity.PuntosJugador1 = dto.PuntosJugador1;
            entity.PuntosJugador2 = dto.PuntosJugador2;
            return entity;
        }

    }
}
