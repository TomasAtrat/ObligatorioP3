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
    public class ReclamoController : Controller
    {
        // GET: Reclamo
        [HttpGet]
        public ActionResult Listar()
        {
            IControllers ReclamoController = new ControllerReclamos();
            List<DtoReclamo> colReclamos=  ReclamoController.ListAll().Cast<DtoReclamo>().ToList();
            return View(colReclamos);
        }

        public ActionResult Agregar()
        {
            IControllers TypeController = new L_ControllerTipoReclamo();            
            List<DtoTipoReclamo> colDto= TypeController.ListAll().Cast<DtoTipoReclamo>().ToList();
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
        public ActionResult AgregarReclamo()
        {
            return View();
        }
    }
}