using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using CommonSolution.Dto;

namespace DataAccess.Mapper
{
    public class ReclamosMapper
    {


        public t_RECLAMO mapToEntity(DtoReclamo DtoR)
        {
            t_RECLAMO reclamo = new t_RECLAMO();
            reclamo.ID = DtoR.id;
            reclamo.Latitud = DtoR.lat;
            reclamo.Longitud = DtoR.lgn;
            reclamo.Observaciones = DtoR.observaciones;
            reclamo.Estado = DtoR.Estado.ToString();
            return reclamo;
        }

        public List<t_RECLAMO> mapToListEntity(List<DtoReclamo> dtoReclamo)
        {
            List<t_RECLAMO> rec = new List<t_RECLAMO>();
            foreach(DtoReclamo r in dtoReclamo)
            {
                rec.Add(mapToEntity(r));
            }
            return rec;
        }


        // De entity a dto

        public DtoReclamo mapToEntity(t_RECLAMO entity)
        {
            DtoReclamo reclamo = new DtoReclamo();
            reclamo.id = entity.ID;
            reclamo.lat = entity.Latitud;
            reclamo.lgn = entity.Longitud;
            reclamo.observaciones= entity.Observaciones;
            int i=reclamo.Estado.CompareTo((entity.Estado).ToString());
            reclamo.Estado = (Estado)Enum.Parse(typeof(Estado), entity.Estado);
            return reclamo;
        }

        public List<DtoReclamo> mapToListEntity(List<t_RECLAMO> Entity)
        {
            List<DtoReclamo> rec = new List<DtoReclamo>();
            foreach (t_RECLAMO r in Entity)
            {
                rec.Add(mapToEntity(r));
            }
            return rec;
        }

        
    }
}
