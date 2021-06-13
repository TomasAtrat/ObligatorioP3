using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using CommonSolution.Dto;

namespace DataAccess.Mapper
{
    public class Tipo_ReclamoMapper
    {
        public t_TIPO_RECLAMO mapToEntity(DtoTipoReclamo TRDTO)
        {
            t_TIPO_RECLAMO tipo = new t_TIPO_RECLAMO();
            tipo.ID = TRDTO.id;
            tipo.Nombre = TRDTO.nombre;
            tipo.Descripcion = TRDTO.descripcion;
            return tipo;
        }
    }
}
