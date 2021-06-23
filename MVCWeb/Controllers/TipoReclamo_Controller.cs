using System;
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
      
        [HttpPost]
        public ActionResult Agregar(IDto dto)
        {
            IControllersAbm control = new L_ControllerTipoReclamo();
            control.Alta(dto);
            return View("Listar");
        }

        public ActionResult Listar()
        {
            IControllersAbm control = new L_ControllerTipoReclamo();
            List<DtoTipoReclamo> lista =control.ListAll().Cast<DtoTipoReclamo>().ToList();
            return View(lista);
        }


    }
}