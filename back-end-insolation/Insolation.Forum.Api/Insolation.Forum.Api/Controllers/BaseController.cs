using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insolation.Forum.Api.Controllers
{
    public class BaseController : ApiController
    {
        public IEnumerable<string> GetAudience()
        {
            KeyValuePair<string, IEnumerable<string>> jwtAudience = Request.Headers.FirstOrDefault(x => x.Key == "JwtAudience");
            return jwtAudience.Value;
        }
    }
}
