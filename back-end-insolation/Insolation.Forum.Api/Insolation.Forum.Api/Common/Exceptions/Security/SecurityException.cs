using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insolation.Forum.Api.Common.Exceptions.Security
{
    public class SecurityException : Exception
    {
        public SecurityException() : base("Credenciais inválidas.")
        {

        }
        public SecurityException(string message) : base(message)
        {

        }
    }
}