using BussinesLogic.Controladores;
using CommonSolution.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class CuadrillaController : Controller
    {
        // GET: Cuadrilla
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(DtoCuadrilla dto)
        {
             

            return View();

        }

    }
}
