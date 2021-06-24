﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonSolution.Interfaces;
using BussinesLogic.Interfaces;
using BussinesLogic.Controladores;
using CommonSolution.Dto;

namespace MVCWeb.Controllers
{
    public class TipoReclamo_Controller : Controller
    {
        public ActionResult Agregar()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(DtoTipoReclamo dto)
        {
            IControllersAbm control = new L_ControllerTipoReclamo();
            control.Alta(dto);
            return View();
        }

        public ActionResult Listar()
        {
            IControllersAbm control = new L_ControllerTipoReclamo();
            List<DtoTipoReclamo> lista =control.ListAll().Cast<DtoTipoReclamo>().ToList();
            return View(lista);
        }

        public ActionResult Delete(string id)
        {
            IControllersAbm control = new L_ControllerTipoReclamo();
            DtoTipoReclamo dto = control.
        }
    }
}