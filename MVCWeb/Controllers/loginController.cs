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

namespace MVCWeb.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return Redirect("/Reclamo/Listar");

            return View();
        }

        [HttpPost]
        public ActionResult Login(DtoLogin dto)
        {
            LControllerLogin login = new LControllerLogin();
            DtoUsuario usuario = login.Registrado(dto.NombreUsuario, dto.Password);
            if (usuario != null && (bool)usuario.EsFuncionario)
            {
                FormsAuthentication.SetAuthCookie(dto.NombreUsuario, true);
                Session[CLogin.KEY_SESSION_USERNAME] = dto.NombreUsuario;
                Session[CLogin.KEY_SESSION_ERROR] = "";
                return Redirect("/Reclamo/Listar");
            }
            Session[CLogin.KEY_SESSION_ERROR] = "Ups... al parecer no estás registrado en el sistema.";

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