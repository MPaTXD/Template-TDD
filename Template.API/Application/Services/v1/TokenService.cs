using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Collections.Generic;
using Template.Domain.ModelAggregate.v1.UserAggregate;

namespace Template.API.Application.Services.v1
{
    public class TokenService
    {
        public static AuthResponse GenerateToken(User user)
        {
            var auth = new AuthResponse();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(user.UserId)),
                    new Claim("UserId", Convert.ToString(user.UserId)),
                }),
                Expires = auth.Expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            auth.Token = tokenHandler.WriteToken(token);
            return auth;
        }
    }
    public class AuthResponse
    {
        public string Token { get; set; }
        public bool Master { get; set; }
        public DateTime Expires { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }
}
