using System.IO;
using System.Text.Json.Serialization;
using Autofac;
using FluentValidation.AspNetCore;
using Hahn.ApplicationProcess.February2021.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Hahn.ApplicationProcess.February2021.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var clientUrl = Configuration.GetValue<string>("Urls:Client");
            var apiUrl = Configuration.GetValue<string>("Urls:Api");
            services.AddControllers(options =>
                {
                    options.Filters.Add(typeof(ValidateModelStateAttribute));
                })
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<ValidateModelStateAttribute>())
                .AddControllersAsServices()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            DemoDbContext.ConnectionString = Configuration.GetConnectionString("SDb");
            services.AddDbContext<DemoDbContext>(options =>
                options.UseNpgsql(DemoDbContext.ConnectionString));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "My API - V1",
                        Version = "v1"
                    }
                );
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "SwaggerExamples.xml");
                c.IncludeXmlComments(filePath);
            });
            services.AddCors(o => o.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader().WithOrigins(clientUrl, apiUrl).AllowCredentials();
                }));

        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacModule>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseRouting();
            using var scope = app.ApplicationServices.CreateScope();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger UI");
            });
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints => { endpoints.MapControllers().RequireCors("CorsPolicy"); });
        }
    }
}