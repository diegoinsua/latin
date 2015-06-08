using LatinCMS.DAOs;
using LatinCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
