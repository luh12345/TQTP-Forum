using Insolation.Forum.Api.Models.Auth;
using Insolation.Forum.Api.Services.Jwt;
using Insolation.Forum.Api.Services.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insolation.Forum.Api.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IJwtTokenService jwtService;
        private readonly ILoginService loginService;

        public AuthController(IJwtTokenService jwtService, ILoginService loginService)
        {
            this.jwtService = jwtService;
            this.loginService = loginService;
        }

        /// <summary>
        /// Create an authorize token for valid users
        /// </summary>
        /// <param name="model">User credentials</param>
        /// <returns>Auth token</returns>
        public HttpResponseMessage Post([FromBody] AuthModel model)
        {

            IEnumerable<string> roles = loginService.Login(model.Username, model.Password);
            KeyValuePair<string, IEnumerable<string>> jwtAudience = Request.Headers.FirstOrDefault(x => x.Key == "JwtAudience");

            if (jwtAudience.Value == null)
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid or null audiance.");

            string jwtToken = jwtService.CreateToken(model.Username, jwtAudience.Value.First(), roles);
            return Request.CreateResponse(HttpStatusCode.OK, jwtToken);
        }
    }
}
