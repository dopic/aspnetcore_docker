using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AspNetCoreDocker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rootPath = Directory.GetCurrentDirectory();

           var config = new ConfigurationBuilder()
                .SetBasePath(rootPath)
                .AddJsonFile("host.json")
                .Build();
            
           var host = new WebHostBuilder()
                .UseContentRoot(rootPath)
                .UseConfiguration(config)
                .UseStartup<Startup>()      
                .UseKestrel()
                .Build();

           host.Run();
        }
    }
}
