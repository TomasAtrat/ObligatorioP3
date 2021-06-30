using BussinesLogic.Controladores;
using BussinesLogic.Interfaces;
using CommonSolution.Dto;
using CommonSolution.Interfaces;
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
            IControllers ZonaController = new ControllerZona();
            List<DtoZona> colZonas = ZonaController.ListAll().Cast<DtoZona>().ToList();
            List<SelectListItem> colOpZonas = new List<SelectListItem>();
            foreach (DtoZona item in colZonas)
            {
                SelectListItem option = new SelectListItem();
                option.Value = item.id.ToString();
                option.Text = item.nombre;
                colOpZonas.Add(option);
            }

            ViewBag.OpZonas = colOpZonas;

            return View();
        }

        [HttpPost]
        public ActionResult Agregar(DtoCuadrilla dto)
        {
            LControllerCuadrilla cuadrillaNueva = new LControllerCuadrilla();
            cuadrillaNueva.Alta(dto);

            return RedirectToAction("Agregar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            LControllerCuadrilla cuadrillaNueva = new LControllerCuadrilla();
            List<DtoCuadrilla> listaDeCuadrilla = cuadrillaNueva.ListAll().Cast<DtoCuadrilla>().ToList();
            return View(listaDeCuadrilla);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            LControllerCuadrilla cuadrillaNueva = new LControllerCuadrilla();
            DtoCuadrilla identificacion = cuadrillaNueva.ExtraerId(id);
            return View(identificacion);
        }

        [HttpPost]
        public ActionResult Edit(DtoCuadrilla dto)
        {
            LControllerCuadrilla cuadrillaNueva = new LControllerCuadrilla();
            cuadrillaNueva.Modificacion((IDto)dto);

            return Redirect("~/Cuadrilla/Listar");
        }


        public ActionResult Delete(long id)
        {
            LControllerCuadrilla cuadrillaControler = new LControllerCuadrilla();
            DtoCuadrilla cuadrilla = new DtoCuadrilla();
            cuadrilla.id = id;
            cuadrillaControler.Baja(cuadrilla);
            return Redirect("~/Cuadrilla/Listar");
        }

    }
}
