using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CommonSolution.Dto
{
    public class DtoTipoReclamo : IDto
    {
        [DisplayName("Id")]
        public long id { get; set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El campo {0} Es Requerido")]
        [Remote("ValidarNombre", "TipoReclamo_", ErrorMessage = "El tipo de reclamo ya fue ingresado")]
        public string nombre { get; set; }
        [DisplayName("Descripcion")]
        [Required(ErrorMessage = "El campo {0} Es Requerido")]
        public string descripcion { get; set; }
    }
}
