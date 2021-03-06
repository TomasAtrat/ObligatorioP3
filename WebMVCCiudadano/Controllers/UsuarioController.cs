using BussinesLogic.Controladores;
using CommonSolution.Constantes;
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

        public ActionResult RecuperarCodigoView()
        {
            return View("RecuperarCodigo");
        }

        public ActionResult RecuperarCodigo(DtoUsuario dto)
        {
            LControllerUsuario controller = new LControllerUsuario();
            DtoUsuario user = controller.getUserByMail(dto.Email);
            if(user!= null && (bool)!user.EsFuncionario)
            {
                this.EnviarMail(user);
            }
            else
            {
                Session[CLogin.KEY_SESSION_EMAIL_MSSG] = $"Ups... parece que aún no te has registrado";
            }

            return View();
        }

        private void EnviarMail(DtoUsuario user)
        {

            string subject = "Recupera tu cuenta de TOLEDO RESPONDE";
            string message = $"<h2>¡Hola {user.NombreUsuario}! </h2> <p> Tu nombre de usuario en TOLEDO RESPONDE es: <b>{user.NombreUsuario} </b>" +
                            $"y tu contraseña es: <b> {user.Password}. </b> </p> <p> ¡Muchas gracias por tu colaboración con la comunidad! </p> " +
                            $" <br /> <p> Si no has solicitado esta información puedes ignorar este mensaje </p>";
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(user.Email);
            mailMessage.Subject = subject;
            mailMessage.SubjectEncoding = Encoding.UTF8;

            mailMessage.Body = message;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress("AyuntamientoToledo@gmail.com");

            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
            cliente.Credentials = new NetworkCredential("AyuntamientoToledo@gmail.com", "ayuntamientotoledo");
            cliente.EnableSsl = true;

            try
            {
                cliente.Send(mailMessage);
                Session[CLogin.KEY_SESSION_EMAIL_MSSG] = $"Se ha enviado un correo a {user.Email} con tu nombre de usuario y contraseña";
            }
            catch (Exception e)
            {
                Session[CLogin.KEY_SESSION_EMAIL_MSSG] = e.Message;
            }
        }
    }
}