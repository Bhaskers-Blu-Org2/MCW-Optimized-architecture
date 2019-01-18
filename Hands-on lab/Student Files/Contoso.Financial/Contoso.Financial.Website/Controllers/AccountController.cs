using Contoso.Financial.Website.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web.Security;

namespace Contoso.Financial.Website.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        { }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            // set some Default credentials to make lab easier
            var model = new LoginViewModel
            {
                Email = "bill@contoso.com",
                Password = "test"
            };

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);           
            
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = "~/Manage/Index";
            }

            return RedirectToLocal(returnUrl);
        }
        
        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}