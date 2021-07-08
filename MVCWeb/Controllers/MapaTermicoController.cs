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
    public class MapaTermicoController : Controller
    {
        
        public ActionResult Mapatermico()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListPunto(DateTime Inicio, DateTime Fin)
        {
            LControllerMapaTermico Lcontroller= new LControllerMapaTermico();
            List<DtoPunto> PuntosReclamo = Lcontroller.PuntosReclamos(Inicio, Fin);

            return Json(PuntosReclamo,JsonRequestBehavior.AllowGet);
        
        }


    }
}
