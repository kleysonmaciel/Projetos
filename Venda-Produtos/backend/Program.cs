using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ProdutoWeb{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder() =>
        CreateHostBuilder.CreateHostBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => 
        {
            webBuilder.UseStartup<Startup>();
        });
    }
}