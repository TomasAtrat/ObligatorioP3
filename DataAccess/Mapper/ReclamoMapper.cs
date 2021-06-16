using CommonSolution.Dto;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonSolution.Interfaces;

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
            dto.IDZona = rec.IDZona;
            dto.Latitud = rec.Latitud;
            dto.Longitud = rec.Longitud;
            dto.Observaciones = rec.Observaciones;
            dto.Estado = (Estado)Enum.Parse(typeof(Estado), rec.Estado);
            dto.FechaHoraIngreso = rec.FechaHoraIngreso;
            dto.colUsuarios = (this.usuarioMapper.MapToListEntity((List<t_USUARIO>)rec.t_USUARIO));

            return dto;
        }

        public List<DtoReclamo> mapToListDtoB(List<t_RECLAMO> colRec)
        {
            List<DtoReclamo> colDtos = new List<DtoReclamo>();
            if (colRec != null)
                colRec.ForEach(i => colDtos.Add(this.mapToDto(i)));
            return colDtos;
        }

        public List<IDto> mapToListDto(List<t_RECLAMO> colRec)
        {
            List<IDto> colDtos = new List<IDto>();
           foreach(t_RECLAMO r in colRec)
            {
                DtoReclamo reclamo = this.mapToDto(r);
                colDtos.Add(reclamo);
            }
            return colDtos;
        }

        public List<t_RECLAMO> mapToListEntity(List<DtoReclamo> colRec)
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
            rec.IDZona = dto.IDZona;
            rec.Latitud = dto.Latitud;
            rec.Longitud = dto.Longitud;
            rec.Observaciones = dto.Observaciones;
            rec.Estado = dto.Estado.ToString();
            rec.FechaHoraIngreso = dto.FechaHoraIngreso;
            rec.t_USUARIO = (ICollection<t_USUARIO>)dto.colUsuarios;
            return rec;
        }
    }
}
