using BussinesLogic.Controladores;
using CommonSolution.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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
            LControllerUsuario controller = new LControllerUsuario();
            DtoUsuario user = controller.getUserByMail(dto.Email);
            if(user!= null && (bool)!user.EsFuncionario)
            {
                string subject = "Recupera tu cuenta de TOLEDO RESPONDE";
                string message = $"¡Hola {dto.NombreUsuario}! Tu nombre de usuario en TOLEDO RESPONDE es: {dto.NombreUsuario} " +
                    $"y tu contraseña es: {dto.Password}. Muchas gracias por tu colaboración con la comunidad";
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(dto.Email);
                mailMessage.Subject = subject;
                mailMessage.SubjectEncoding = Encoding.UTF8;

                mailMessage.Body = message;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = false;
                mailMessage.From = new MailAddress("AyuntamientoToledo@gmail.com");

                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                cliente.Credentials = new NetworkCredential("AyuntamientoToledo@gmail.com", "ayuntamientotoledo");
                cliente.EnableSsl = true;
            }
            return View();
        }
    }
}