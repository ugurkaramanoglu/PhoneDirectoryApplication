using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectoryApp.APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
                 WebHost.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   config
                   .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                   .AddJsonFile("Ocelot.json")
                   .AddEnvironmentVariables();

               }).UseStartup<Startup>().UseSerilog();
    }
}
