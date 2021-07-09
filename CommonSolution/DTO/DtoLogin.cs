using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    public class DtoLogin
    {

        [DisplayName("Nombre de usuario")]
        [StringLength(50, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]

        public string NombreUsuario { get; set; }

        [DisplayName("Contraseña")]
        [StringLength(50, ErrorMessage = "La {0} no puede superar {1}")]
        [Required(ErrorMessage = "La {0} es requerido")]

        public string Password { get; set; }
    }
}
