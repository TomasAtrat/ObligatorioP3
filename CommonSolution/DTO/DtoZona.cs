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
    public class DtoZona : IDto
    {
        public long id;
        [DisplayName("Nombre")]
        [Required]
        [StringLength(50)]
        [Remote("ValidarNombre", "Zona", ErrorMessage = "Ya existe una zona con ese nombre")]
        public string nombre { get; set; }
        [DisplayName("Color")]
        [Required]
        public string color { get; set; }
        public bool Estado;
        public List<DtoPunto> colPuntos { get; set; }
        public List<DtoCuadrilla> colCuadrillas= new List<DtoCuadrilla>();
    }
}
