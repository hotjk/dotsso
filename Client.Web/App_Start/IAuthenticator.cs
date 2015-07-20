using Grit.Utility.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Client.Web
{
    public interface IAuthenticator
    {
        ICookieTicketConfig CookieTicketConfig { get; }
        HttpCookie GetCookieTicket(string content);
        bool ValidateCookieTicket(HttpCookie cookie, out CookieTicket ticket, out HttpCookie renewCookie);
    }
}