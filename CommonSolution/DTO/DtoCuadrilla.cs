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
    public class DtoCuadrilla : IDto
    {
        public long id { get; set; }
        [DisplayName("Encargado")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string encargado { get; set; }
        [DisplayName("Nombre")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string nombre { get; set; } 
        [DisplayName("Cantidad de peones")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public int cantidadPeones { get; set; }
        [DisplayName("Observaciones")]
        [StringLength(250, ErrorMessage = "La observacion no puede superar 250 caracteres")]
        public string Observaciones { get; set; }
        [DisplayName("Id Zona")]
        [Required]
        public long idZona { get; set; }
        public bool Estado;

        public DtoZona dtoZona;
        public List<DtoReclamo> colReclamos = new List<DtoReclamo>();
    }
}
