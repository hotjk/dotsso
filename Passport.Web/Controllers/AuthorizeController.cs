using Grit.Utility.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Passport.Web.Controllers
{
    public class AuthorizeController : Controller
    {
        public IAuthenticator Authenticator { get; protected set; }
        public int? UserId { get; set; }

        public AuthorizeController(IAuthenticator authenticator)
        {
            this.Authenticator = authenticator;
        }

        public int? TryGetUserId()
        {
            if (UserId != null)
            {
                return UserId;
            }
            HttpCookie cookie = Request.Cookies.Get(Authenticator.CookieTicketConfig.CookieName);
            HttpCookie newCookie;
            CookieTicket ticket;
            if (Authenticator.ValidateCookieTicket(cookie, out ticket, out newCookie))
            {
                UserId = int.Parse(ticket.Name);
            }
            return UserId;
        }
    }
}