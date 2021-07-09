using BussinesLogic.Controladores;
using CommonSolution.Constantes;
using CommonSolution.Dto;
using CommonSolution.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebMVCCiudadano.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated == true)
                return Redirect("/Reclamo/Agregar");

            return View();
        }

        [HttpPost]
        public ActionResult Login(DtoLogin dto)
        {
            LControllerLogin controller = new LControllerLogin();
            DtoUsuario usuario = controller.Registrado(dto.NombreUsuario, dto.Password);
            if ((bool)!usuario.EsFuncionario)
            {
                FormsAuthentication.SetAuthCookie(dto.NombreUsuario, false);
                Session[CLogin.KEY_SESSION_USERNAME] = dto.NombreUsuario;
                return Redirect("/Reclamo/Agregar");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            //SignOut() Limpia la Cookie de Autenticación
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}