using CommonSolution.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controllers
{
    public class JugadorController
    {
        public JugadorController()
        {
            this.repository = new Repository();
        }

        private Repository repository;

        public Repository Repository { get => repository; }
    } 
}
