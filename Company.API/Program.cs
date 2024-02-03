using Company.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Company.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
     Host.CreateDefaultBuilder(args)
         .ConfigureWebHostDefaults(webBuilder =>
         {
             webBuilder.UseStartup<Startup>()
                 // Configurar el servicio de logging.
                 .ConfigureLogging(logging =>
                 {
                     logging.ClearProviders(); 
                     logging.AddConsole(); 
                                         
                 });
         });

    }
}