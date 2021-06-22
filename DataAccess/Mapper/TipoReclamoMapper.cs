using CommonSolution.Dto;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
  public class TipoReclamoMapper
    {
        /*public TipoReclamoMapper()
        {
            this.tipoReclamoMapper = new TipoReclamoMapper();
        }*/

    
       
        public DtoTipoReclamo mapToDto(t_TIPO_RECLAMO entity)
        {
            DtoTipoReclamo dto = new DtoTipoReclamo();
            dto.id = entity.ID;
            dto.nombre = entity.Nombre;
            dto.descripcion = entity.Descripcion;

            return dto;
        }

        public t_TIPO_RECLAMO maptoentity(DtoTipoReclamo dto)
        {
            t_TIPO_RECLAMO entity = new t_TIPO_RECLAMO();

            entity.ID = dto.id;
            entity.Nombre = dto.nombre;
            entity.Descripcion = dto.descripcion;

            return entity;
        }

        public List<DtoTipoReclamo> maptoDto(List<t_TIPO_RECLAMO> entity)
        {
            List<DtoTipoReclamo> colDtos = new List<DtoTipoReclamo>();
            if (entity != null)
                entity.ForEach(i => colDtos.Add(this.mapToDto(i)));

            return colDtos;
        }

        public List<t_TIPO_RECLAMO> maptoDto(List<DtoTipoReclamo> dto)
        {
            List<t_TIPO_RECLAMO> Colentity = new List<t_TIPO_RECLAMO>();
            if (dto != null)
                dto.ForEach(i => Colentity.Add(this.maptoentity(i)));

            return Colentity;
        }
    }
}
