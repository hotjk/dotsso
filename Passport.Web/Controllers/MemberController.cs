using Grit.Utility.Security;
using Passport.Model;
using Passport.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Passport.Web.Controllers
{
    public class MemberController : AuthorizeController
    {
        private IPassportClientService _passportClientService;

        public MemberController(IAuthenticator authenticator, IPassportClientService passportClientService) 
            : base(authenticator)
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
            int userId = 1;
            var cookie = this.Authenticator.GetCookieTicket(userId.ToString());
            Response.Cookies.Add(cookie);
            var token = Convert.ToBase64String(new TokenSource(userId.ToString()).ByteData);
            var returnURL = loginVM.RedirectURL;
            return View("LoginSuccess", new LoginSuccessVM { Token = token, ReturnURL = returnURL });
        }
    }
}