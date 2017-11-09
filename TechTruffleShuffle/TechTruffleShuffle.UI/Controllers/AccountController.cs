using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TechTruffleShuffle.Data;
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
        [ValidateAntiForgeryToken]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel()
            {
                ReturnlUrl = returnUrl
            };
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var ctx = HttpContext.GetOwinContext();
            //var userManager = ctx.GetUserManager<UserManager<ApplicationUser>>();
            var userManager = ctx.GetUserManager<ApplicationUserManager>();

            var authManager = ctx.Authentication;
            var user = userManager.Find(model.UserName, model.Password);

            if(user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(model.ReturnlUrl))
                {
                    return Redirect(model.ReturnlUrl);
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }          
            }
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
           
            var authMgr = Request.GetOwinContext().Authentication;

            authMgr.SignOut("ApplicationCookie");

            return RedirectToAction("Index","Home");
        }
        //[HttpPost]
        //public ActionResult LogOff()
        //{
        //    return RedirectToAction("Login");
        //}

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
            var context = new TechTruffleShuffleEntities();
            ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var context = new TechTruffleShuffleEntities();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName};
            UserStore<ApplicationUser> Store = new UserStore<ApplicationUser>(new TechTruffleShuffleEntities());
            ApplicationUserManager userManager = new ApplicationUserManager(Store);
            var result = userManager.Create(user, model.Password);
            

            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, model.UserRoles);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");

            return View();
        }

        [HttpGet]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            return View(model);

        }

        [HttpPost]
        public async Task <ActionResult> ResetPassword(string userName, string userId, string newPassword, ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var context = new TechTruffleShuffleEntities();
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);
            //ApplicationUser applicationUser = new ApplicationUser();
            userName = model.UserName;
            //userId = model. applicationUser.Id;
            var findUser = context.Users.SingleOrDefault(u=> u.UserName == userName);

            userId = findUser.Id;



            //userId = User.Identity.GetUserId();//"<YourLogicAssignsRequestedUserId>";

            newPassword = model.ConfirmPassword; //"<PasswordAsTypedByUser>";
            string hashedNewPassword = UserManager.PasswordHasher.HashPassword(newPassword);
            ApplicationUser cUser = UserManager.FindById(userId);
            store.SetPasswordHashAsync(cUser, hashedNewPassword);
            store.UpdateAsync(cUser);
            return View();

            //ApplicationDbContext = new ApplicationDbContext()
            //String userId = "<YourLogicAssignsRequestedUserId>";
            //String newPassword = "<PasswordAsTypedByUser>";
            //ApplicationUser cUser = UserManager.FindById(userId);
            //String hashedNewPassword = UserManager.PasswordHasher.HashPassword(newPassword);
            //UserStore<ApplicationUser> store = new UserStore<ApplicationUser>();
            //store.SetPasswordHashAsync(cUser, hashedNewPassword);
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