using Microsoft.IdentityModel.Tokens;

namespace AspNetCoreDocker.Auth
{
    public class JwtSettings
    {
        public SymmetricSecurityKey SecurityKey { get; }        
        public int TokenExpiration { get; }
        public string Audience { get; } = "DummyAudience";
        public string Issuer { get; }  = "DummyIssuer";   

        public JwtSettings (SymmetricSecurityKey securityKey, int tokenExpiration)
        {
            SecurityKey =  securityKey;
            TokenExpiration = tokenExpiration;
        }
    }
}