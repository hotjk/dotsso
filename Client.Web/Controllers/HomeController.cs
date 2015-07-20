using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Web.Controllers
{
    public class HomeController : AuthorizeController
    {
        public HomeController(IAuthenticator authenticator)
            : base(authenticator)
        {
        }

        public ActionResult Index()
        {
            TryGetUserId();
            return View(UserId);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}