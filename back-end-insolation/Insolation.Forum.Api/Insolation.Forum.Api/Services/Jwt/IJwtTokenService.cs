using System.Collections.Generic;

namespace Insolation.Forum.Api.Services.Jwt
{
    public interface IJwtTokenService
    {
        string CreateToken(string username, string audience, IEnumerable<string> roles);
        bool ValidateToken(string token);
    }
}