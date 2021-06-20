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
    public class DtoZona : IDto
    {
        [ReadOnly(true)]
        public long id;
        [DisplayName("Nombre")]
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
        [DisplayName("Color")]
        [Required]
        public string color { get; set; }
        public List<DtoPunto> colPuntos { get; set; }
        public List<DtoCuadrilla> colCuadrillas;
    }
}
