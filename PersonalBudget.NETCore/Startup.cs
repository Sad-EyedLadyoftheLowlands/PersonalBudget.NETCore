using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

using PersonalBudget.NETCore.Services;
using PersonalBudget.NETCore.Controllers;

namespace PersonalBudget.NETCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        
        // Method used to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton(Configuration);
            
            // Services declared as singleton.
            services.AddSingleton<ITestService, TestService>();
            services.AddSingleton<IAllAccountsService, AllAccountsService>();
            
            // TODO: FIX POLICY OF ALLOWING ANY METHOD OR HEADER.
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()//WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddControllers();
        }
        
        // Http request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionpage();
            }
            */
            app.UseHttpsRedirection();
            
            // TODO: THESE LINES SHOULD NOT BE NECESSARY SINCE ANGULAR TAKES CARE OF THE FRONTEND.
            app.UseDefaultFiles(); // Serves index.html by default.
            app.UseStaticFiles(); // Files in wwwroot are searched first.

            app.UseCors("CorsPolicy");
            app.UseRouting();
            
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}