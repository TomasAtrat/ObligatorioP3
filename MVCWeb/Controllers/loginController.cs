using BussinesLogic.Controladores;
using BussinesLogic.Interfaces;
using CommonSolution.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinesLogic.Interfaces;
using BussinesLogic.Controladores;
using System.Web.Security;
using CommonSolution.DTO;
using CommonSolution.Constantes;

namespace MVCWeb.Controllers
{
    public class loginController : Controller
    {

        public ActionResult login()
        {
            if (User.Identity.IsAuthenticated == true) 
            {
                return Redirect("/home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult login(DtoLogin log)
        {
            LControllerlogin control = new LControllerlogin();
            DtoUsuario user = control.Registrado(log.Usuario,log.Contraceña);
        if     (log.Usuario == user.NombreUsuario && log.Contraceña == user.Password &&user != null ) 
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