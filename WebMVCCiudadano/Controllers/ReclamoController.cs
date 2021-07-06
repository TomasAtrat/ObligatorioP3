using BussinesLogic.Controladores;
using BussinesLogic.Interfaces;
using CommonSolution.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class ReclamoController : Controller
    {
        public ActionResult Agregar()
        {
            IControllers TypeController = new L_ControllerTipoReclamo();
            List<DtoTipoReclamo> colDto = TypeController.ListAll().Cast<DtoTipoReclamo>().ToList();
            List<SelectListItem> colTiposReclamos = new List<SelectListItem>();

            foreach (DtoTipoReclamo item in colDto)
            {
                SelectListItem option = new SelectListItem();
                option.Value = item.id.ToString();
                option.Text = item.nombre;
                colTiposReclamos.Add(option);
            }

            ViewBag.colTipos = colTiposReclamos;

            return View();
        }

        [HttpPost]
        public ActionResult AgregarReclamo(DtoReclamo dto)
        {
            IControllers ControllerReclamo = new ControllerReclamos();
            ControllerReclamo.Alta(dto);
            return RedirectToAction("Agregar");
        }

        [HttpGet]
        public ActionResult ListarReclamos()
        {
            IControllers ReclamoController = new ControllerReclamos();
            List<DtoReclamo> colReclamos = ReclamoController.ListAll().Cast<DtoReclamo>().OrderBy(i => i.FechaHoraIngreso).ToList();
            return View(colReclamos);
        }

        [HttpGet]
        public ActionResult VerHistorico(long id)
        {
            ControllerReclamos controller = new ControllerReclamos();
            List<DtoHistoricoReclamo> colDtos = controller.VerHistorico(id);
            return View(colDtos);
        }

    }
}