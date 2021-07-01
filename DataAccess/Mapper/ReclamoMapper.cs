using CommonSolution.Dto;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ReclamoMapper
    {
        public ReclamoMapper()
        {
            this.usuarioMapper = new UsuarioMapper();
        }

        private UsuarioMapper usuarioMapper;

        public DtoReclamo mapToDto(t_RECLAMO rec)
        {
            DtoReclamo dto = new DtoReclamo();
            dto.ID = rec.ID;
            dto.IDCuadrilla = rec.IDCuadrilla;
            dto.IDTipoReclamo = rec.IDTipoReclamo;
            dto.IDZona = rec.IDZona.ToString();
            dto.Latitud = rec.Latitud;
            dto.Longitud = rec.Longitud;
            dto.Observaciones = rec.Observaciones;
            dto.Estado = (Estado)Enum.Parse(typeof(Estado), rec.Estado);
            dto.FechaHoraIngreso = rec.FechaHoraIngreso;
            dto.EstadoLogic = (bool)rec.EstadoL;
            dto.colUsuarios = this.usuarioMapper.MapToListDto(rec.t_USUARIO.ToList());

            return dto;
        }

        public List<DtoReclamo> mapToListDto(List<t_RECLAMO> colRec)
        {
            List<DtoReclamo> colDtos = new List<DtoReclamo>();
            if (colRec != null)
                colRec.ForEach(i => colDtos.Add(this.mapToDto(i)));
            return colDtos;
        }

        public List<t_RECLAMO> mapToListDto(List<DtoReclamo> colRec)
        {
            List<t_RECLAMO> colDtos = new List<t_RECLAMO>();
            if (colRec != null)
                colRec.ForEach(i => colDtos.Add(this.mapToEntity(i)));
            return colDtos;
        }

        public t_RECLAMO mapToEntity(DtoReclamo dto)
        {
            t_RECLAMO rec = new t_RECLAMO();
            rec.ID = dto.ID;
            rec.IDCuadrilla = dto.IDCuadrilla;
            rec.IDTipoReclamo = dto.IDTipoReclamo;
            rec.IDZona = long.Parse(dto.IDZona);
            rec.Latitud = dto.Latitud;
            rec.Longitud = (double)dto.Longitud;
            rec.Observaciones = dto.Observaciones;
            rec.Estado = dto.Estado.ToString();
            rec.FechaHoraIngreso = dto.FechaHoraIngreso;
            rec.EstadoL = dto.EstadoLogic;
            rec.t_USUARIO = this.usuarioMapper.MapToListEntity(dto.colUsuarios);
            return rec;
        }

        public List<t_RECLAMO> mapToEntity(List<DtoReclamo> colDto)
        {
            List<t_RECLAMO> colReclamos = new List<t_RECLAMO>();
            if (colDto != null)
                colDto.ForEach(i => colReclamos.Add(this.mapToEntity(i)));
            return colReclamos;
        }
    }
}
