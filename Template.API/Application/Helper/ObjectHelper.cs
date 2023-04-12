using System.Collections.Generic;
using System.Security.Claims;
using System;
using System.Linq;

namespace Template.API.Application.Helper
{
    public static class ObjectHelper
    {
        public static string ExtractObjectValue(ClaimsIdentity claimIdentity, string param)
        {
            IEnumerable<Claim> claims = claimIdentity.Claims;
            var value = claims.FirstOrDefault(x => x.Type == param);
            if (value == null)
            {
                throw new Exception("Token inválido, por favor tente gerar um token novo através da rota authenticate.");
            }

            return value.Value;
        }
        public static int ExtractObjectValueInt(ClaimsIdentity claimIdentity, string param)
        {
            IEnumerable<Claim> claims = claimIdentity.Claims;
            var value = claims.FirstOrDefault(x => x.Type == param);
            if (value == null)
            {
                throw new Exception("Token inválido, por favor tente gerar um token novo através da rota authenticate.");
            }

            return Convert.ToInt32(value.Value);
        }
    }
}
