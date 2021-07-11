
using CommonSolution.Dto;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class Historico_Mapper
    {
        public Historico_Mapper()
        {

        }

        public DtoHistoricoReclamo mapToDto(t_HISTORICO_ESTADO_RECLAMO entity)
        {
            DtoHistoricoReclamo dto = new DtoHistoricoReclamo();
            dto.Comentarios = entity.Comentarios;
            dto.EstadoActual = entity.EstadoActual;
            dto.EstadoAnterior = entity.EstadoAnterior;
            dto.FechaHoraCambio = entity.FechaHoraCambio;
            dto.ID = entity.ID;
            dto.FechaHoraIngreso = entity.FechaHoraIngreso;
            dto.IDReclamo = entity.IDReclamo;
            dto.Latitud = entity.Latitud;
            dto.Longitud = entity.Longitud;
            dto.DescripcionReclamo = entity.DescripcionReclamo;
            dto.nombreUsuario = entity.NombreUsuario;
            return dto;            
        }

        public List<DtoHistoricoReclamo> mapToDto(List<t_HISTORICO_ESTADO_RECLAMO> colEn)
        {
            List<DtoHistoricoReclamo> colDtos = new List<DtoHistoricoReclamo>();
            if (colEn != null)
                colEn.ForEach(i => colDtos.Add(this.mapToDto(i)));
            return colDtos;
        }

        
        public t_HISTORICO_ESTADO_RECLAMO mapToEntity(DtoHistoricoReclamo dto)
        {
            t_HISTORICO_ESTADO_RECLAMO entity = new t_HISTORICO_ESTADO_RECLAMO();
            entity.Comentarios = dto.Comentarios;
            entity.EstadoActual = dto.EstadoActual;
            entity.EstadoAnterior = dto.EstadoAnterior;
            entity.FechaHoraCambio = dto.FechaHoraCambio;
            entity.ID = dto.ID;
            entity.FechaHoraIngreso = dto.FechaHoraIngreso;
            entity.IDReclamo = dto.IDReclamo;
            entity.Latitud = dto.Latitud;
            entity.Longitud = dto.Longitud;
            entity.NombreUsuario = dto.nombreUsuario;
            return entity;
        }

        public List<t_HISTORICO_ESTADO_RECLAMO> mapToDto(List<DtoHistoricoReclamo> colDtos)
        {
            List<t_HISTORICO_ESTADO_RECLAMO> colEn = new List<t_HISTORICO_ESTADO_RECLAMO>();
            if (colDtos != null)
                colDtos.ForEach(i => colEn.Add(this.mapToEntity(i)));
            return colEn;
        }


    }
}
