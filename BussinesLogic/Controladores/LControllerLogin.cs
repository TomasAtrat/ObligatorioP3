using CommonSolution.Dto;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controladores
{
 public   class LControllerLogin
    {
        public LControllerLogin()
        {
            this.repository = new Repository();
        }
        private Repository repository;
       
        
        public bool estaReigtrado(string nobre, string contracena)
        {
            DtoUsuario user = this.repository.UsuarioRepository.getElementById(nobre, contracena);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
