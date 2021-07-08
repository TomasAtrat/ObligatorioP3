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
            dto.Observaciones = Cuadrilla.Observaciones;
            return dto;
        }

        public t_CUADRILLA mapToCommonEntity(DtoCuadrilla dto)
        {
            t_CUADRILLA entity = new t_CUADRILLA();
            entity.CantidadPeones = (short)dto.cantidadPeones;
            entity.Encargado = dto.encargado;
            entity.Estado = dto.Estado;
            entity.ID = dto.id;
            entity.Nombre = dto.nombre;
            entity.Observaciones = dto.Observaciones;
            return entity;
        }

        public List<t_CUADRILLA> mapToCommonEntity(List<DtoCuadrilla> colDtos)
        {
            List<t_CUADRILLA> colCuadrillas = new List<t_CUADRILLA>();
            if (colDtos != null)
                colDtos.ForEach(i => colCuadrillas.Add(this.mapToCommonEntity(i)));
            return colCuadrillas;
        }

        public DtoCuadrilla mapToDto(t_CUADRILLA_ZONA cuadrilla)
        {
            DtoCuadrilla dto = new DtoCuadrilla();
            dto.idZona = cuadrilla.IDZona;
            dto.id = cuadrilla.IDCuadrilla;
            dto.colReclamos = this.reclamoMapper.mapToDto(cuadrilla.t_RECLAMO1.ToList());
            return dto;
        }

        public t_CUADRILLA_ZONA mapToEntity(DtoCuadrilla dto)
        {
            t_CUADRILLA_ZONA zona = new t_CUADRILLA_ZONA();
            zona.IDCuadrilla = dto.id;
            zona.IDZona = dto.idZona;
            zona.t_RECLAMO1 = this.reclamoMapper.mapToEntity(dto.colReclamos);
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
        
        public DtoCuadrilla mapToDtoFromView(VW_HistoricoDateDiffByCuadrilla vista)
        {
            DtoCuadrilla dto = new DtoCuadrilla();
            dto.sumaHoras = (int)vista.suma;
            dto.id = vista.ID;
            return dto;
        }

        public List<DtoCuadrilla> mapToDtoFromView(List<VW_HistoricoDateDiffByCuadrilla> colViews)
        {
            List<DtoCuadrilla> colDtos = new List<DtoCuadrilla>();
            if (colViews != null)
                colViews.ForEach(i => colDtos.Add(this.mapToDtoFromView(i)));
            return colDtos;
        }

        public List<DtoCuadrilla> mapToDto(List<t_CUADRILLA> colCuad)
        {
            List<DtoCuadrilla> colDtos = new List<DtoCuadrilla>();
            if (colCuad != null)
                colCuad.ForEach(i => colDtos.Add(this.mapToDto(i)));
            return colDtos;
        }
    }
}
