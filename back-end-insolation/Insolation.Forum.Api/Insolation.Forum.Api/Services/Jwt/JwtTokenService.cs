using Insolation.Forum.Api.Common.Const;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace Insolation.Forum.Api.Services.Jwt
{
    public class JwtTokenService : IJwtTokenService
    {
        private JwtSecurityTokenHandler TokenHandler;
        private string JwtKey;
        private string[] Audiences;

        public JwtTokenService()
        {
            TokenHandler = new JwtSecurityTokenHandler();
            JwtKey = ConfigurationManager.AppSettings["jwt.key"];
            Audiences = ConfigurationManager.AppSettings["jwt.audience"].Split(';');
        }

        public string CreateToken(string username, string audience, IEnumerable<string> roles)
        {
            if (ValidateAudience(audience))
            {
                string issuer = DomainConst.CurrentDomain;
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));
                SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                claimsIdentity.AddClaim(new Claim("username", username));
                claimsIdentity.AddClaim(new Claim("user_id", "1"));
                claimsIdentity.AddClaim(new Claim("roles", JsonConvert.SerializeObject(roles)));

                JwtSecurityToken jwtSecurityToken = TokenHandler.CreateJwtSecurityToken(issuer, audience, claimsIdentity, DateTime.Now, DateTime.Now.AddDays(10), DateTime.Now, credentials);

                return TokenHandler.WriteToken(jwtSecurityToken);
            }
            else
            {
                throw new Exception("Audience não permitido para gerar token");
            }
        }

        private bool ValidateAudience(string audiance)
        {
            return Audiences.Any(x => x.Equals(audiance));
        }

        public bool ValidateToken(string token)
        {
            try
            {
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));

                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidIssuer = DomainConst.CurrentDomain,
                    ValidAudiences = Audiences,
                    IssuerSigningKey = securityKey,
                    RequireExpirationTime = true,
                };

                TokenHandler.ValidateToken(token, validationParameters, out var securityToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}