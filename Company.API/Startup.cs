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
    public class Startup
    {
        public IConfiguration Configuration
        {
            get;
        }
        public IWebHostEnvironment WebHostEnvironment
        {
            get;
        }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
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
           services.AddSwaggerGen(c =>
           {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Company.API", Version = "v1" });
            });
            services.AddMvcCore();
            services.AddEndpointsApiExplorer();

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {

            app.Use(async (context, next) =>
            {
                await using (var ms = new MemoryStream())
                {
                    var body = context.Response.Body;
                    context.Response.Body = ms;
                    await next.Invoke();
                    ms.Seek(0, SeekOrigin.Begin);
                    await ms.CopyToAsync(body);
                    string responseBody = Encoding.UTF8.GetString(ms.ToArray());
                    //Console.WriteLine(responseBody);
                    logger.LogInformation(responseBody);
                    context.Response.Body = body;
                }
            });


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