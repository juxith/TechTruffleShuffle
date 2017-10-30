using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTruffleShuffle.UI.Models;

namespace TechTruffleShuffle.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmEmail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ExternalLoginConfrimation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        public ActionResult SendCode()
        {
            return View();
        }
        public ActionResult VerifyCode()
        {
            return View();
        }
        public ActionResult _ExternalLoginsListPartial()
        {
            return View();
        }


    }
}