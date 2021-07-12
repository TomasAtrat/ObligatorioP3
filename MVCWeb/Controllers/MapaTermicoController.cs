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

        [HttpGet]
        public JsonResult ListPunto(DtoReclamo dto)
        {
            LControllerMapaTermico Lcontroller= new LControllerMapaTermico();
            List<DtoPunto> PuntosReclamo = Lcontroller.PuntosReclamos(DateTime.Parse(dto.inicio), DateTime.Parse(dto.fin));
            return Json(PuntosReclamo,JsonRequestBehavior.AllowGet);
        
        }


    }
}
