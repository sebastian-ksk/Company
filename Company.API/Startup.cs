using Company.API.Middlewares;
using Company.API.Services;
using Company.BLL.Services;
using Company.DAL.DBConnections;
using Company.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;


namespace Company.API
{
    public class LoggerHttpResponseMidleware
    {
        public IConfiguration Configuration
        {
            get;
        }
        public IWebHostEnvironment WebHostEnvironment
        {
            get;
        }

        public LoggerHttpResponseMidleware(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            WebHostEnvironment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
          

            string user = "sa";
            string password = "123456789";
            string server = "LOCALHOST";
            string database = "AdsProduccion";
            string connectionString = $"Server={server};Database={database};User Id={user};Password={password};TrustServerCertificate=true;";

            services.AddSingleton(connectionString); 

            //DB context se instancia en AddScoped para que se cree una nueva instancia por cada request
            services.AddDbContext<CompanyContext>(options => options.UseSqlServer(connectionString)); 
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // * Para que los enums se serialicen como strings
            });

            services.AddEndpointsApiExplorer();

            //caching
            services.AddResponseCaching();

           services.AddSwaggerGen(c =>
           {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Company.API", Version = "v1" });
            });
            services.AddMvcCore();
            services.AddEndpointsApiExplorer();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

            //Type services
            // AddScoped: Crea una nueva instancia por cada request
            // AddSingleton: Crea una sola instancia por aplicación
            // AddTransient: Crea una nueva instancia por cada llamada

            services.AddTransient<ServiceTransient>();
            services.AddScoped<ServiceScoped>();
            services.AddSingleton<ServiceSingleton>();
            services.AddTransient<ILifeTimeService, LifeTimeService>();

            ///Services Api
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUsersRepository, UsersRepository>();




        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<LoggerHttpResponseMidleware> logger)
        {

            //app.UseMiddleware<LoggerHttpResponseMidleware>();


            //Esto intercepta completamente el pipeline de request y response
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            //app.Map("/error", app =>
            //    app.Run(async context =>
            //    {
            //        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            //        var exception = exceptionHandlerPathFeature.Error;
            //        var path = exceptionHandlerPathFeature.Path;
            //        await context.Response.WriteAsync($"Error: {exception.Message}");
            //    })
              
            //);
            

            app.UseLoggerHttpResponseMidleware();

            // Configure the HTTP request pipeline.
            if (env.IsEnvironment("Local") || env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
     
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}