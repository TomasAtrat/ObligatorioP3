﻿using BussinesLogic.Interfaces;
using CommonSolution.Interfaces;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controladores
{
    public class ControllerTipoReclamo : IControllers
    {
        public ControllerTipoReclamo()
        {
            this.repository = new Repository();
        }

        private Repository repository;

        public List<string> Alta(IDto dto)
        {
            throw new NotImplementedException();
        }

        public List<string> Baja(IDto dto)
        {
            throw new NotImplementedException();
        }

        public List<string> Modificacion(IDto dto)
        {
            throw new NotImplementedException();
        }
    }
}