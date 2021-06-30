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
       
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string Usuario { get; set; }

        [DisplayName("contraceña")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string Contraceña { get; set; }

    }
}
