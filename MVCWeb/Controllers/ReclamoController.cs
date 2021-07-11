using BussinesLogic.Controladores;
using BussinesLogic.Interfaces;
using CommonSolution.Constantes;
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
            List<DtoReclamo> colReclamos = controller.ListAll().Cast<DtoReclamo>().Where(i=>i.Estado!= Estado.RESUELTO).ToList();
            var reclamos = colReclamos.Select(i => new { ID = i.ID, Estado = i.Estado.ToString(), FechaHoraIngreso = i.FechaHoraIngreso, IDCuadrilla = i.IDCuadrilla, IDZona = i.IDZona, Latitud = i.Latitud, Longitud = i.Longitud, Observaciones = i.Observaciones, difHoras = Math.Round(((TimeSpan)(DateTime.Now - i.FechaHoraIngreso)).TotalHours) }); // Si no se hace 
            return Json(reclamos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Editar(long id)
        {
            ControllerReclamos controller = new ControllerReclamos();
            DtoReclamo dto = controller.getElementById(id);
            List<SelectListItem> colEstados = new List<SelectListItem>();
            foreach (string item in Enum.GetNames(typeof(Estado)))
            {
                SelectListItem option = new SelectListItem();
                option.Text = item;
                option.Value = Enum.Parse(typeof(Estado), item).ToString();
                colEstados.Add(option);
            }

            ViewBag.colEstados = colEstados;
            return View(dto);
        }

        [HttpPost]
        public ActionResult Editar(DtoReclamo dto)
        {
            ControllerReclamos controller = new ControllerReclamos();
            dto.Estado = (Estado)Enum.Parse(typeof(Estado), dto.estado);
            controller.CambiarEstadoReclamo(dto);
            DtoHistoricoReclamo dtoHistoricoReclamo = controller.VerHistorico().Last();
            dtoHistoricoReclamo.Comentarios = dto.Comentarios;
            dtoHistoricoReclamo.nombreUsuario = (string)Session[CLogin.KEY_SESSION_USERNAME];
            controller.ActualizarHistorico(dtoHistoricoReclamo);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult NuevoReporte(long id)
        {
            ControllerReclamos controller = new ControllerReclamos();
            DtoReclamo dto = controller.getElementById(id);
            return View(dto);
        }

        [HttpPost]
        public ActionResult NuevoReporte(DtoReclamo dto)
        {
            ControllerReporte controller = new ControllerReporte();
            List<string> colErrores = controller.GenerarReporte(dto);
            string s = "";
            if (colErrores.Count == 0)
            {
                s = controller.ToHtml(dto.directorio, dto.ID);
            }

            Process.Start(s);
            return RedirectToAction("Listar");
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

        [HttpGet]
        public ActionResult ListarPorEstado(string estado)
        {
            ControllerReclamos controller = new ControllerReclamos();
            List<DtoReclamo> colDtos = controller.ListarPorEstado(estado);
            return View("Listar", colDtos);
        }

    }
}