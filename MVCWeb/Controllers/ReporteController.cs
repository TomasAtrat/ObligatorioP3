using BussinesLogic.Controladores;
using CommonSolution.Dto;
using CommonSolution.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class ReporteController : Controller
    {
        [HttpGet]
        public ActionResult ReclamosAtrasados()
        {
            ControllerReporte controller = new ControllerReporte();
            List<DtoReclamosAtrasados> colDtos = controller.getReclamosAtrasados();
            return View(colDtos);
        }

        [HttpGet]
        public ActionResult CuadrillasMasEficientes()
        {
            ControllerReporte controller = new ControllerReporte();
            List<DtoCuadrilla> colDtos = controller.cuadrillasMasEficientes().OrderBy(i => i.promedio).ToList();
            return View(colDtos);
        }

        public ActionResult MapaTermico()
        {
            return View("MapaTermico");
        }

        [HttpGet]
        public JsonResult ListPunto(DtoReclamo dto)
        {
            ControllerReporte controller = new ControllerReporte();
            List<DtoPunto> PuntosReclamo = new List<DtoPunto>();
            try
            {
                PuntosReclamo = controller.PuntosReclamos(DateTime.Parse(dto.inicio), DateTime.Parse(dto.fin));
            }
            catch (Exception)
            {
            }

            return Json(PuntosReclamo, JsonRequestBehavior.AllowGet);
        }

    }
}