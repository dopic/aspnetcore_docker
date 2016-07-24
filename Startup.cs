using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

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

            services.AddMvc();            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}