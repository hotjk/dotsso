using Client.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Web.Controllers
{
    public class PassController : Controller
    {
        public ActionResult Index(PassVM vm)
        {
            return View();
        }
    }
}