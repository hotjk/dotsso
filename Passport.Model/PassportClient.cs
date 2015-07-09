using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Model
{
    public class PassportClient
    {
        public PassportClient()
        {

        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Host { get; private set; }
        public string TokenUrl { get; private set; }
        public string PrivateKey { get; private set; }
        public string PublicKey { get; private set; }
    }
}
