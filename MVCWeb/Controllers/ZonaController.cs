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

        public ActionResult Listar()
        {
            ControllerZona zona = new ControllerZona();
            List<DtoZona> colZonas= zona.ListAll().Cast<DtoZona>().ToList();
            
            return View(colZonas);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult AgregarZona(DtoZona dto)
        {
            return View("Agregar");
        }
    }
}