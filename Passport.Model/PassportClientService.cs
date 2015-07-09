using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Model
{
    public class PassportClientService : IPassportClientService
    {
        public PassportClient PassportClientByHost(string domain)
        {
            return new PassportClient();
        }
    }
}
