﻿using BussinesLogic.Controladores;
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
        public ActionResult Login(DtoUsuario dto)
        {
            LControllerUsuario usuario = new LControllerUsuario();
            usuario.ExtraerUsuaroFuncionario(dto);
            
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