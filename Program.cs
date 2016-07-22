using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AspNetCoreDocker
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("host.json")
                .Build();
            
           var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseStartup<Startup>()      
                .UseKestrel()
                .Build();

           host.Run();
        }
    }
}
