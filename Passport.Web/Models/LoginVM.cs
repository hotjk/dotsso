using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Passport.Web.Models
{
    public class LoginVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RedirectURL { get; set; }
    }
}