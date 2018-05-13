using Isen.DotNet.Library.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Isen.DotNet.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            
            using (var scope = host.Services.CreateScope())
            {
                var seed = scope.ServiceProvider.GetService<SeedData>();
                seed.DropDatabase();
                seed.CreateDatabase();
                /*Excercie 3*/
                seed.ImportCategories();
                seed.ImportDepartement();
                seed.ImportCommunes();
                seed.ImportPointsInteret();
                /*Excercie 2*//*
                seed.AddDepartements();
                seed.AddCommunes();
                seed.AddAdresses();
                seed.AddCategories();
                seed.AddPointsInteret();
                */
            }
            
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
