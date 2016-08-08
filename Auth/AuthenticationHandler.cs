using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AspNetCoreDocker.Auth
{
    public class AuthenticationHandler : IJwtBearerEvents
    {
        private EFContext _context;

        public AuthenticationHandler(EFContext context)
        {
            _context = context;
        }

        public Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            return Task.FromResult(0);
        }

        public Task Challenge(JwtBearerChallengeContext context)
        {
            return Task.FromResult(0);
        }

        public Task MessageReceived(MessageReceivedContext context)
        {
            return Task.FromResult(0);
        }

        public Task TokenValidated(TokenValidatedContext context)
        {
            var userName = context.Ticket.Principal.Identity.Name;

            if(!_context.Users.Any(u=> u.UserName == userName))
            {
                context.Response.StatusCode = 401;    
                context.SkipToNextMiddleware();   
            }

            return Task.FromResult(0);
        }
    }

}