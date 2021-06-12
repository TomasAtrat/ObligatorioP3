using CommonSolution.Dto;
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

        public List<DtoCuadrilla> maptoDto(List<t_CUADRILLA> entity)
        {
            List<DtoCuadrilla> colDtos = new List<DtoCuadrilla>();
            if (entity != null)
                entity.ForEach(i => colDtos.Add(this.mapToDto(i)));

            return colDtos;
        }

        public List<t_CUADRILLA> maptoDto(List<DtoCuadrilla> dto)
        {
            List<t_CUADRILLA> Colentity = new List<t_CUADRILLA>();
            if (dto != null)
                dto.ForEach(i => Colentity.Add(this.maptoentity(i)));

            return Colentity;
        }


    }
}
