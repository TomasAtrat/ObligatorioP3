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
        public long id;
        [DisplayName("encargado")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string encargado { get; set; }
        [DisplayName("nombre")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string nombre { get; set; } 
        [DisplayName("cantidadPeones")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public int cantidadPeones { get; set; }
        [DisplayName("Obvservaciones")]
        [StringLength(250, ErrorMessage = "La obvservacion nopuede superar 250 caracteres")]
        public string Observaciones { get; set; }
        [DisplayName("IdZona")]
        [Required]
        public long idZona { get; set; }
        public bool Estado;
        
        public List<DtoReclamo> colReclamos;
    }
}
