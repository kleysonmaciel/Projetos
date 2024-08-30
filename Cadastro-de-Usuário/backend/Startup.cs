using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ClienteApi.Data;

namespace ClienteApi{
    public class Startup{
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services){
            //Configura o Entity Framework com o PostgreSQL
            services.AddDbContext<ClienteApiDbContext>(options =>
            opitions.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ClienteService>();
            services.AddControllers;
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>{
                endpoints.MspControllers();
            });
        }
    }
}