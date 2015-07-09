using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Model
{
    public interface IPassportClientService
    {
        PassportClient PassportClientByHost(string domain);
    }
}
