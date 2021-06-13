using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Persistencia;

namespace BussinesLogic.Controladores
{
    public class ClienteController
    {
        private Repository _Repositorio;
        public ClienteController()
        {
            this._Repositorio = new Repository();
        }
    }
}
