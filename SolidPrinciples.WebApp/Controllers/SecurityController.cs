﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolidPrinciple.Security.Legacy;
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
                try
                {
                    new CredentialManager().ChangePassword(model.CurrentPassword, model.NewPassword, model.ConfirmedNewPassword);
                    ViewData.Add("Message", "Your password has been changed successfully");
                }
                catch (Exception ex)
                {
                    ViewData.Add("ErrorMessage", ex.Message);
                }    
            }

            return View();
        }
    }
}