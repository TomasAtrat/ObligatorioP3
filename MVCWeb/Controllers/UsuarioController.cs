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

            return Redirect("Listar");

        }
        [UserAuthentication]
        public ActionResult Listar()
        {
            LControllerUsuario controller = new LControllerUsuario();
            List<DtoUsuario> dto = controller.ListarFuncionarios();
            return View(dto);
            

        }
        [UserAuthentication]
        public ActionResult ListarClientes()
        {
            LControllerUsuario controller = new LControllerUsuario();
            List<DtoUsuario> dto = controller.ListarUsuarios();
            return View(dto);
        }



        [UserAuthentication]
        public ActionResult Delete(string NombreUsuario, string password)
        {
            DtoUsuario usuario = new DtoUsuario();
            usuario.NombreUsuario = NombreUsuario;
            usuario.Password = password;
            LControllerUsuario user = new LControllerUsuario();
            user.Baja(usuario);
            return Redirect("Listar");

        }
        [UserAuthentication]
        public ActionResult Edit(string NombreUsuario, string password)
        {
            LControllerUsuario context = new LControllerUsuario();
            return View(context.ExtraerPorNyP(NombreUsuario, password));
        }
        [UserAuthentication]
        [HttpPost]
        public ActionResult Edit(DtoUsuario UppDateUser)
        {
            LControllerUsuario context = new LControllerUsuario();
            context.Modificacion(UppDateUser);

            return Redirect("Listar");
        }
    }
}