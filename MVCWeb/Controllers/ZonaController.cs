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
            var zonas = colZonas.Select(i => new { nombre = i.nombre, color = i.color, colPuntos = i.colPuntos , id= i.id}); // Si no se hace 
            return Json(zonas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarZona(DtoZona zona)
        {
            IControllers ControllerZona = new ControllerZona();
            ControllerZona.Alta(zona);
            return View("Agregar");
        }
    }
}