using Grit.Utility.Authentication;
using Passport.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Passport.Web
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var controller = filterContext.Controller as AuthorizeController;
            if (controller == null)
            {
                throw new Exception("Invald authorize controller.");
            }
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies.Get(controller.Authenticator.CookieTicketConfig.CookieName);

            HttpCookie newCookie;
            CookieTicket ticket;
            if (controller.Authenticator.ValidateCookieTicket(cookie, out ticket, out newCookie))
            {
                controller.UserId = int.Parse(ticket.Name);
                if (newCookie != null)
                {
                    filterContext.HttpContext.Response.Cookies.Add(newCookie);
                }
                return;
            }

            filterContext.Result = new RedirectResult(controller.Authenticator.CookieTicketConfig.LoginUrl);
        }
    }
}