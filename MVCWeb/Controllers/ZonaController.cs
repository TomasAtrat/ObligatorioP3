using BussinesLogic.Controladores;
using BussinesLogic.Interfaces;
using CommonSolution.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class ZonaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            ControllerZona zona = new ControllerZona();
            List<DtoZona> colZonas = zona.ListAll().Cast<DtoZona>().ToList();

            return View(colZonas);
        } 

        [HttpGet]
        public JsonResult getZonas()
        {
            ControllerZona zona = new ControllerZona();
            List<DtoZona> colZonas = zona.ListAll().Cast<DtoZona>().ToList();
            return Json(colZonas);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult AgregarZona(DtoZona zona)
        {
            IControllers ControllerZona = new ControllerZona();
            ControllerZona.Alta(zona);
            return View("Agregar");
        }
    }
}