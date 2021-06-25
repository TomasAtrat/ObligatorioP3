using BussinesLogic.Controladores;
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
            return View(); 
        }

        public ActionResult Edit()
        {
            return View("Modificar");
        }

        public ActionResult Modificar(DtoCuadrilla dto)
        {
            LControllerCuadrilla cuadrillaNueva = new LControllerCuadrilla();
            cuadrillaNueva.Modificacion((IDto)dto);

            return Redirect("~/Cuadrilla/Listar");
        }
        [HttpPost]
        public ActionResult Agregar(DtoCuadrilla dto)
        {
            LControllerCuadrilla cuadrillaNueva = new LControllerCuadrilla();
            cuadrillaNueva.Alta(dto);

            return View("Agregar"); 
        }
        public ActionResult Listar()
        {
            LControllerCuadrilla cuadrillaNueva = new LControllerCuadrilla();
            List<DtoCuadrilla> listaDeCuadrilla = cuadrillaNueva.ListAll().Cast<DtoCuadrilla>().ToList();
            return View(listaDeCuadrilla);
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
