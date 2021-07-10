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
    public class DtoUsuario : IDto
    {
        [DisplayName("Nombre Usuario")] 
        [StringLength(50, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [Remote("ValidarNombre", "Usuario", ErrorMessage = "Ya existe un usuario con ese nombre")]
        public string NombreUsuario { get; set; }
        
        [DisplayName("Contraseña")]
        [StringLength(50, ErrorMessage = "La {0} no puede superar {1}")]
        [Required(ErrorMessage = "La {0} es requerido")]

        public string Password { get; set; }
      
        [DisplayName("Nombre")]
        [StringLength(50, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string Nombre { get; set; }
       
        [DisplayName("Apellido")]
        [StringLength(50, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]

        public string Apellido { get; set; }

        [DisplayName("Email")]
        [StringLength(320, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]

        public string Email { get; set; }

        [DisplayName("Telefono")]
        [StringLength(50, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]

        public string Telefono { get; set; }


        [DisplayName("Es Funcionario?")]
        
        public bool? EsFuncionario { get; set; }

        public bool? Estado;



        public List<DtoReclamo> colReclamos;
    }
}
