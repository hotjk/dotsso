using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Passport.Web.Models
{
    public class LoginSuccessVM
    {
        public string Token { get; set; }
        public string ReturnURL { get; set; }
    }
}