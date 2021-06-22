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
        public CuadrillaMapper()
        {
            this.reclamoMapper = new ReclamoMapper();
        }

        private ReclamoMapper reclamoMapper;

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

        public DtoCuadrilla mapToDto(t_CUADRILLA_ZONA cuadrilla)
        {
            DtoCuadrilla dto = new DtoCuadrilla();
            dto.idZona = cuadrilla.IDZona;
            dto.id = cuadrilla.IDCuadrilla;
            dto.colReclamos = this.reclamoMapper.mapToDto(cuadrilla.t_RECLAMO.ToList());
            return dto;
        }

        public t_CUADRILLA_ZONA mapToEntity(DtoCuadrilla dto)
        {
            t_CUADRILLA_ZONA zona = new t_CUADRILLA_ZONA();
            zona.IDCuadrilla = dto.id;
            zona.IDZona = dto.idZona;
            zona.t_RECLAMO = this.reclamoMapper.mapToEntity(dto.colReclamos);
            return zona;
        }

        public List<DtoCuadrilla> mapToDto(List<t_CUADRILLA_ZONA> colCuadrillas)
        {
            List<DtoCuadrilla> colDtos = new List<DtoCuadrilla>();
            if (colCuadrillas != null)
                colCuadrillas.ForEach(i => colDtos.Add(this.mapToDto(i)));
            return colDtos;
        }

        public List<t_CUADRILLA_ZONA> mapToEntity(List<DtoCuadrilla> colDto)
        {
            List<t_CUADRILLA_ZONA> colCuadrillas = new List<t_CUADRILLA_ZONA>();
            if (colDto != null)
                colDto.ForEach(i => colCuadrillas.Add(this.mapToEntity(i)));
            return colCuadrillas;
        }

    }
}
