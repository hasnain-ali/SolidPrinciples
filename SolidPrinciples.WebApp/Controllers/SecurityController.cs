using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolidPrinciples.Security.SuperClean;
using SolidPrinciples.WebApp.Models;
using SolidPrinciples.Security.Interfaces;

namespace SolidPrinciples.WebApp.Controllers
{
    public class SecurityController : Controller
    {
        private ICredentialService _credentialService = new CredentialService();

        public SecurityController()
        {
            _credentialService = new CredentialService();
        }

        public SecurityController(ICredentialService credentialService)
        {
            _credentialService = credentialService;
        }

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
                    _credentialService.ChangePassword(GetCurrentUser(), model.CurrentPassword, model.NewPassword, model.ConfirmedNewPassword);
                    ViewData.Add("Message", "Your password has been changed successfully");
                }
                catch (Exception ex)
                {
                    ViewData.Add("ErrorMessage", ex.Message);
                }    
            }

            return View();
        }

        private static string GetCurrentUser()
        {
            return "demo.user";
        }
    }
}