using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Dto
{
    public class DtoTipoReclamo : IDto
    {
        [DisplayName("Id")]
        public long id { get;  }
    [DisplayName("Nombre")]
        [Required(ErrorMessage = "El campo {0} Es Requerido")]
        public string nombre { get; set; }
        [DisplayName("Descripcion")]
        [Required(ErrorMessage = "El campo {0} Es Requerido")]
        public string descripcion { get; set; }
    }
}
