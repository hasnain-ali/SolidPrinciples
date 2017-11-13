using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolidPrinciples.WebApp.Models;

namespace SolidPrinciples.WebApp.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                
            }

            return View();
        }
    }
}