using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AspNetCoreDocker.Auth
{
    public class AuthenticationHandler : JwtBearerEvents
    {
        public override Task TokenValidated(TokenValidatedContext context)
        {
            var userName = context.Ticket.Principal.Identity.Name;

            var dbContext = context.HttpContext.RequestServices.GetService(typeof(EFContext)) as EFContext;
            
            if(!dbContext.Users.Any(u=> u.UserName == userName))
            {
                context.Response.StatusCode = 401;    
                context.SkipToNextMiddleware();   
            }            

            return Task.FromResult(0);
        }
    }

}
