using Insolation.Forum.Api.Common.Exceptions.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insolation.Forum.Api.Services.Login
{
    public class LoginService : ILoginService
    {
        public IEnumerable<string> Login(string username, string password)
        {
            IList<string> roles = new List<string>();

            if (username.Equals("admin") && password.Equals("admin"))
            {
                roles.Add("admin");
            }
            else if (username.Equals("luh12345") && password.Equals("Rasengan.1998"))
            {
                roles.Add("guest");
            }
            else
                throw new SecurityException();

            return roles;
        }
    }
}