using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;

namespace AspNetCoreDocker.Auth
{
    public class JwtProvider
    {
        private JwtSecurityTokenHandler _tokenHandler;
        private JwtSettings _settings;    

        public JwtProvider (JwtSettings settings, JwtSecurityTokenHandler tokenHandler)
        {
            _settings = settings;
            _tokenHandler = tokenHandler;
        }

        public string CreateEncoded(string userName)
        {
            return _tokenHandler.CreateEncodedJwt(new SecurityTokenDescriptor
            {           
                Subject = new ClaimsIdentity(new GenericIdentity(userName)),
                Expires = DateTime.UtcNow.AddDays(_settings.TokenExpiration),
                SigningCredentials = new SigningCredentials(_settings.SecurityKey, SecurityAlgorithms.HmacSha256Signature),
                Audience = _settings.Audience,
                Issuer = _settings.Issuer
            });       

        }        
    }
}