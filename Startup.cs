using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorPagingAdoNet.Models.Options;
using RazorPagingAdoNet.Models.Services.Application;
using RazorPagingAdoNet.Models.Services.Infrastructure;

namespace RazorPagingAdoNet
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRazorPages();

            services.AddTransient<IUserService, AdoNetUserService>();
            services.AddTransient<IDatabaseAccessor, SqliteDatabaseAccessor>();
            services.Configure<ConnectionStringsOptions>(Configuration.GetSection("ConnectionStrings"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseExceptionHandler("/Error");
                // Breaking change .NET 5: https://docs.microsoft.com/en-us/dotnet/core/compatibility/aspnet-core/5.0/middleware-exception-handler-throws-original-exception
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandlingPath = "/Error",
                    AllowStatusCode404Response = true
                });
            }
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.UseEndpoints(routeBuilder => {
                routeBuilder.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routeBuilder.MapRazorPages();
            });
        }
    }
}
