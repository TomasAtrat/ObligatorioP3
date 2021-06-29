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
    public class DtoUsuario : IDto
    {
        [DisplayName("Nombre Usuario")] 
        [StringLength(100, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]
       
        public string NombreUsuario { get; set; }
        
        [DisplayName("Password")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]

        public string Password { get; set; }
      
        [DisplayName("Nombre")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string Nombre { get; set; }
       
        [DisplayName("Apellido")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]

        public string Apellido { get; set; }

        [DisplayName("Email")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]

        public string Email { get; set; }

        [DisplayName("Telefono")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]

        public string Telefono { get; set; }


        [DisplayName("Es Funcionario?")]
        
        public bool? EsFuncionario { get; set; }

        public bool? Estado;



        public List<DtoReclamo> colReclamos;
    }
}
