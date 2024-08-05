using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProdutoWeb.Data;

namespace ProdutoWeb{
    public class Startup{
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services){
            services.AddContext<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 21))));

            services.AddControllers();
            services.AddCors(options =>{
                options.AddPolicy("AllowAll",
                builder=>{
                    builder.AllowAnyOrigin();
                           .AllowAnyMethod();
                           .AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IwebHostEnvironment env){
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }else{
                app.UseExceptionHandler("/home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>{
                endpoints.MapControllers();
            });
        }
    }
}