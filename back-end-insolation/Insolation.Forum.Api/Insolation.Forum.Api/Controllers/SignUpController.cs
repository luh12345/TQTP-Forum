using Insolation.Forum.Api.Entities.User;
using Insolation.Forum.Api.Models.SignUp;
using Insolation.Forum.Api.Services.Jwt;
using Insolation.Forum.Api.Services.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Insolation.Forum.Api.Controllers
{
    [EnableCors(methods: "*", headers: "*", origins: "*")]
    public class SignUpController : BaseController
    {
        private readonly ILoginService loginService;
        private readonly IJwtTokenService jwtService;

        public SignUpController(ILoginService loginService, IJwtTokenService jwtService)
        {
            this.loginService = loginService;
            this.jwtService = jwtService;
        }

        public async Task<HttpResponseMessage> Post([FromBody] SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<string> jwtAudiance = GetAudience();
                if (jwtAudiance == null || !jwtAudiance.Any())
                    return Request.CreateResponse("Null or invalid Audiance.");

                User user = await loginService.SignUp(new User
                {
                    Username = model.Username,
                    Password = model.Senha,
                    Email = model.Email,
                    Name = model.Name
                });

                string token = jwtService.CreateToken(user.Username, jwtAudiance.First(), user.Roles.Select(x => x.Descricao));

                return Request.CreateResponse(HttpStatusCode.OK, token);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Select(x => x.Value));
        }
    }
}
