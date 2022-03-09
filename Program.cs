using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            CreateHostBuilder(args).Build().Run();
            var root = Directory.GetCurrentDirectory();
            var dotenv = Path.Combine(root, ".env");
            System.Console.WriteLine("Migrating");
            Console.WriteLine(Environment.GetEnvironmentVariable("connection_str"));
            DotEnv.Load(dotenv);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
