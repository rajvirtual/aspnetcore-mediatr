using Blip.Core.Interfaces;
using Blip.InfraStructure.Data;
using Blip.Web.CustomExceptionMiddleware;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace Blip.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Blip.Core");
            services.AddMediatR(assembly);
            services.AddMvc();
            services.AddCors();
            services.AddDbContext<BlipDbContext>(c => c.UseSqlServer
                 (Configuration.GetConnectionString("BlipConnection")));
            services.AddScoped<IBlipDbContext, BlipDbContext>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Web API",
                    Version = "v1",
                    Description = "ASP.NET Core Web API Mediator Pattern with Mediatr",
                    Contact = new OpenApiContact
                    {
                        Name = "John Smith",
                    },
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSerilogRequestLogging();
            app.ConfigureCustomExceptionMiddleware();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
