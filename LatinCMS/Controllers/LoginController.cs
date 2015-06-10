using LatinCMS.DAOs;
using LatinCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LatinCMS.Controllers
{
    public class LoginController : Controller
    {
        //------------------------
        //       LOGIN
        //------------------------
       
        [HttpGet]
        public ActionResult Login()
        {
               
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModel l)
        {
            if (!ModelState.IsValid)
            {
                return View(l);
            }


            UsuarioDAO userDAO = new UsuarioDAO();
            UsuarioModel user = userDAO.GetByMail(l.Mail);

            if (user != null && String.Equals(l.Mail, user.Mail) && String.Equals(l.Password, user.Password))
            {
                    Session["user"] = user;

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    1,
                    "latincms",
                    DateTime.Now,
                    DateTime.Now.AddYears(100),
                    true,
                    "datosDeUsuario");

                String encryptedTicket = System.Web.Security.FormsAuthentication.Encrypt(authTicket)

                    HttpCookie authCookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, encryptedTicket);

                If (createPersistentCookie)
                    authCookie.Expires = authTicket.Expiration;
                

                Response.Cookies.Add(authCookie);


                    var authTicket = new FormsAuthenticationTicket(
                       1,
                       userName,
                       DateTime.Now,
                       DateTime.Now.AddMinutes(20), // expiry
                       false,
                       roles,
                       "/");
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                      FormsAuthentication.Encrypt(authTicket));
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("FalloLogin", "El usuario o la clave son incorrectos");
            return View(l);
            

        }



        //------------------------
        //   NUEVA CUENTA
        //------------------------
        [HttpGet]
        public ActionResult NuevaCuenta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaCuenta(UsuarioModel u)
        {
            
                if (!ModelState.IsValid) {
                    return View(u);
                }

                else {
                    u.Rol = 1;
                    UsuarioDAO userDAO = new UsuarioDAO();
                    userDAO.Save(u);

                    return RedirectToAction("Index", "Login");
                }
        }


       
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
    }
}
