using Client.Web.Models;
using Grit.Utility.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Web.Controllers
{
    public class PassController : AuthorizeController
    {
        public PassController(IAuthenticator authenticator)
            : base(authenticator)
        {
        }

        public ActionResult Index(PassVM vm)
        {
            var returnURL = vm.ReturnURL;
            var tokenSource = new TokenSource(Convert.FromBase64String(vm.Token));
            string userId = tokenSource.UserData;
            var cookie = this.Authenticator.GetCookieTicket(userId);
            Response.Cookies.Add(cookie);
            return View("Index", vm);
        }
    }
}