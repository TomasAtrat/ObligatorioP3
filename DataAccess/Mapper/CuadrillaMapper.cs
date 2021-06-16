using CommonSolution.Dto;
using CommonSolution.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class CuadrillaMapper
    {
        public DtoCuadrilla mapToDto(t_CUADRILLA Cuadrilla)
        {
            DtoCuadrilla dto = new DtoCuadrilla();
            dto.id = Cuadrilla.ID;
            dto.nombre = Cuadrilla.Nombre;
            dto.encargado = Cuadrilla.Encargado;
            dto.cantidadPeones = Cuadrilla.CantidadPeones;

            return dto;
        }

        public t_CUADRILLA maptoentity(DtoCuadrilla dto)
        {
            t_CUADRILLA cuadrilla = new t_CUADRILLA();

            cuadrilla.ID = dto.id;
            cuadrilla.Nombre = dto.nombre;
            cuadrilla.Encargado = dto.encargado;
            cuadrilla.CantidadPeones = dto.cantidadPeones;

            return cuadrilla;
        }

        public List<IDto> maptoListDto(List<t_CUADRILLA> entity)
        {
            List<IDto> colDtos = new List<IDto>();
            foreach (t_CUADRILLA item in entity)
            {
                DtoCuadrilla dto = this.mapToDto(item);
                colDtos.Add(dto);
            }
            return colDtos;
        }

        public List<t_CUADRILLA> maptoListDto(List<DtoCuadrilla> dto)
        {
            List<t_CUADRILLA> Colentity = new List<t_CUADRILLA>();
            if (dto != null)
                dto.ForEach(i => Colentity.Add(this.maptoentity(i)));

            return Colentity;
        }


    }
}
