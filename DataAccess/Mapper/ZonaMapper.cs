﻿using CommonSolution.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ZonaMapper
    {
        public DtoZona mapToDto(t_ZONA en)
        {
            DtoZona dto = new DtoZona();
            dto.id = en.ID;
            dto.nombre = en.Nombre;
            dto.color = en.Color;

            return dto;
        }

        public t_ZONA mapToEntity(DtoZona dto)
        {
            t_ZONA zona = new t_ZONA();
            zona.ID = dto.id;
            zona.Nombre = dto.nombre;
            zona.Color = dto.color;

            return zona;
        }
    }
}
