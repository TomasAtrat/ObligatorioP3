using CommonSolution.Dto;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class PuntoMapper
    {

        public DtoPunto mapToDto(t_PUNTO punto)
        {
            DtoPunto dto = new DtoPunto();
            dto.id = punto.ID;
            dto.idZona = punto.IDZona;
            dto.lat = punto.Latitud;
            dto.lng = punto.Longitud;
            return dto;
        }

        public List<DtoPunto> mapToDto(List<t_PUNTO> colPuntos)
        {
            List<DtoPunto> colDto = new List<DtoPunto>();
            if (colPuntos != null)
                colPuntos.ForEach(i => colDto.Add(this.mapToDto(i)));
            return colDto;
        }

        public t_PUNTO mapToEntity(DtoPunto dto)
        {
            t_PUNTO punto = new t_PUNTO();
            punto.ID = dto.id;
            punto.IDZona = dto.idZona;
            punto.Latitud = dto.lat;
            punto.Longitud = dto.lng;

            return punto;
        }

        public List<t_PUNTO> mapToEntity(List<DtoPunto> colDtos)
        {
            List<t_PUNTO> colPuntos = new List<t_PUNTO>();
            if (colDtos != null)
                colDtos.ForEach(i => colPuntos.Add(this.mapToEntity(i)));
            return colPuntos;
        }
    }
}
