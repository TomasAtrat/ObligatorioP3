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
            Lusuario.Alta(dto);

            return View();

        }

        public ActionResult Listar()
        {
            LControllerUsuario controller = new LControllerUsuario();
            List<DtoUsuario> dto = controller.ListarFuncionarios();
            return View(dto);
            

        }
    }
}