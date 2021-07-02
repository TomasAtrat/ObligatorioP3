using BussinesLogic.Controladores;
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
    public class loginController : Controller
    {
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("/Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(DtoLogin dto)
        {
            LControllerlogin control = new LControllerlogin();
            DtoUsuario user = control.Registrado(log.Usuario, log.Contraceña);
            if (log.Usuario == user.NombreUsuario && log.Contraceña == user.Password && user != null)
            {

                FormsAuthentication.SetAuthCookie(log.Usuario, false);


                return Redirect("/Home");
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