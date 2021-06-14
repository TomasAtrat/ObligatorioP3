using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonSolution.Dto;
using DataAccess.Model;

namespace DataAccess.Mapper
{
    public class ClienteMapper
    {
        public DtoZona mapToDto(t_ZONA en)
        {
            DtoZona dto = new DtoZona();
            dto.id = en.ID;
            dto.nombre = en.Nombre;
            dto.color = en.Color;
            dto.colPuntos = this.puntoMapper.mapToDto(en.t_PUNTO.ToList());
            retu
    }
}
