﻿using BussinesLogic.Controladores;
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
            List<DtoReclamo> colReclamos = ReclamoController.ListAll().Cast<DtoReclamo>().ToList();
            return View(colReclamos);
        }

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
        public JsonResult getReclamos()
        {
            ControllerReclamos controller = new ControllerReclamos();
            List<DtoReclamo> colReclamos = controller.ListAll().Cast<DtoReclamo>().ToList();
            var reclamos = colReclamos.Select(i => new { ID = i.ID, Estado = i.Estado.ToString(), FechaHoraIngreso = i.FechaHoraIngreso, IDCuadrilla = i.IDCuadrilla, IDZona = i.IDZona, Latitud = i.Latitud, Longitud = i.Longitud, Observaciones = i.Observaciones, difHoras = (DateTime.Now - i.FechaHoraIngreso).Value.Hours }); // Si no se hace 
            return Json(reclamos, JsonRequestBehavior.AllowGet);
        }

        /*[HttpGet]
        public ActionResult ReclamosPorIdCuadrilla(long idCuadrilla)
        {
            ControllerReclamos control = new ControllerReclamos();
            List<DtoReclamo> ListaDeReclamos = control.ExtraerReclamosPorCuadrilla(idCuadrilla);
            return View("Listar", ListaDeReclamos);
        }*/
    }
}