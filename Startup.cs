using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using AspNetCoreDocker.Auth;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AspNetCoreDocker
{
    public class Startup
    {        
        private IConfiguration _configuration;


        public Startup(IHostingEnvironment env)
        {
              _configuration = new ConfigurationBuilder() 
                                .SetBasePath(env.ContentRootPath)                               
                                .AddJsonFile("appsettings.json")
                                .AddEnvironmentVariables()
                                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {           
            var connectionString = _configuration.GetConnectionString("Default");
            services.AddDbContext<EFContext>(options => options.UseSqlite(connectionString));

            var key = Encoding.UTF8.GetBytes(_configuration["Auth:SecurityKey"]);
            var expiration = Int32.Parse(_configuration["Auth:Expiration"]);       
            services.AddSingleton<JwtSettings>(new JwtSettings(new SymmetricSecurityKey(key), expiration));

            services.AddSingleton<AuthenticationHandler>();
            services.AddTransient<JwtSecurityTokenHandler>();
            services.AddTransient<JwtProvider>();
         
            services.AddMvc();            
        }

        public void Configure(IApplicationBuilder app, AuthenticationHandler handler, JwtSettings jwtSettings)
        {
            var key = Encoding.UTF8.GetBytes("MySecurityTokenKey");          

            var validationParameters = new TokenValidationParameters{
                IssuerSigningKey = jwtSettings.SecurityKey,
                ValidAudience = jwtSettings.Audience,
                ValidIssuer = jwtSettings.Issuer
            };              

            var options = new JwtBearerOptions
            {
                Events = handler,
                TokenValidationParameters = validationParameters                                
            };

            app.UseJwtBearerAuthentication(options);

            app.UseMvc();
        }
    }
}