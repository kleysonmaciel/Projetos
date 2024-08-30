using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ClienteApi{
    public class Program{
        public static void Main(string[] args){
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        CreateHostBuilder.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>{
            webBuilder.UseStartup<Startup>();
        });
    }
}