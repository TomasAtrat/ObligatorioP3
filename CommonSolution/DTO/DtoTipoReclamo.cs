﻿using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Dto
{
    public class DtoTipoReclamo : IDto
    {
        public long id;
        public string nombre;
        public string descripcion;
    }
}
