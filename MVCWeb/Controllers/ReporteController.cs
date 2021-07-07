using BussinesLogic.Controladores;
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
        public ActionResult ReclamosAtrasados()
        {
            ControllerReporte controller = new ControllerReporte();
            List<DtoReclamosAtrasados> colDtos=  controller.getReclamosAtrasados();
            return View(colDtos);
        }
    }
}