using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Dto
{
    public class DtoUsuario : IDto
    {
        public string NombreUsuario ;
        public string Password ;
        public string Nombre ;
        public string Apellido ;
        public string Email ;
        public string Telefono ;
        public bool EsFuncionario ;

        public List<DtoReclamo> colReclamos;
    }
}
