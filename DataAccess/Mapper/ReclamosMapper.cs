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
        private Tipo_ReclamoMapper mapperTipoReclamo;

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


    }
}
