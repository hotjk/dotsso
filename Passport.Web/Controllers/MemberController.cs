using Passport.Model;
using Passport.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Passport.Web.Controllers
{
    public class MemberController : Controller
    {
        private IPassportClientService _passportClientService;

        public MemberController(IPassportClientService passportClientService)
        {
            _passportClientService = passportClientService;
        }

        [HttpGet]
        public ActionResult Login(LoginRedirectVM loginVM)
        {
            Uri redirectUri;
            try
            {
                redirectUri = new Uri(loginVM.RedirectURL);
            }
            catch
            {
                throw new ApplicationException("invalid redirect url");
            }
            var client = _passportClientService.PassportClientByHost(redirectUri.Host);
            if (client == null)
            {
                throw new ApplicationException("invalid redirect url");
            }

            return View(new LoginVM());
        }

        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            return View("LoginSuccess", new LoginSuccessVM { Token = Guid.NewGuid().ToString() });
        }
    }
}