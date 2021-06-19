using CommonSolution.Dto;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class HistoricoMapper
    {
        public DtoHistoricoReclamo mapToDto(t_HISTORICO_ESTADO_RECLAMO reclamo)
        {
            DtoHistoricoReclamo dto = new DtoHistoricoReclamo();
            dto.comentarios = reclamo.Comentarios;
            dto.estadoActual = reclamo.EstadoActual;
            dto.estadoAnterior = reclamo.EstadoAnterior;
            dto.fechaHora = reclamo.FechaHoraCambio;
            dto.id = reclamo.ID;
            return dto;
        }

        public List<DtoHistoricoReclamo> mapToDto(List<t_HISTORICO_ESTADO_RECLAMO> colReclamos)
        {
            List<DtoHistoricoReclamo> colDtos = new List<DtoHistoricoReclamo>();
            if (colReclamos != null)
                colReclamos.ForEach(i => colDtos.Add(this.mapToDto(i)));
            return colDtos;
        }
    }
}
