using BussinesLogic.Controladores;
using CommonSolution.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(DtoUsuario dto)
        {
            LControllerUsuario Lusuario = new LControllerUsuario();
            dto.EsFuncionario = false;
            Lusuario.Alta(dto);

            return View();
        }

        public JsonResult ValidarNombre(string NombreUsuario)
        {
            bool res = true;
            LControllerUsuario controller = new LControllerUsuario();
            if (controller.ValidarNombre(NombreUsuario))
                res = false;
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RecuperarCodigo()
        {
            return View();
        }

        public ActionResult RecuperarCodigo(DtoUsuario dto)
        {
            return View();
        }
    }
}