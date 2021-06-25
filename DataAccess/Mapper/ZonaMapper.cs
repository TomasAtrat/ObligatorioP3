using CommonSolution.Dto;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ZonaMapper
    {
        public ZonaMapper()
        {
            this.puntoMapper = new PuntoMapper();
        }

        private PuntoMapper puntoMapper;

        public DtoZona mapToDto(t_ZONA en)
        {
            DtoZona dto = new DtoZona();
            dto.id = en.ID;
            dto.nombre = en.Nombre;
            dto.color = en.Color;
            dto.Estado = en.Estado;
            dto.colPuntos = this.puntoMapper.mapToDto(en.t_PUNTO.ToList());
            return dto;
        }

        public t_ZONA mapToEntity(DtoZona dto)
        {
            t_ZONA zona = new t_ZONA();
            zona.ID = dto.id;
            zona.Nombre = dto.nombre;
            zona.Color = dto.color;
            zona.Estado = dto.Estado;
            zona.t_PUNTO = this.puntoMapper.mapToEntity(dto.colPuntos);
            return zona;
        }

        public List<DtoZona> mapToDto(List<t_ZONA> zonas)
        {
            List<DtoZona> colDtos = new List<DtoZona>();
            if (zonas != null)
                zonas.ForEach(i => colDtos.Add(this.mapToDto(i)));
            return colDtos;
        }
    }
}
