using Company.BLL.Services;
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

            services.AddSingleton(connectionString); // * Inyectar la cadena de conexión

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

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUsersRepository, UsersRepository>();



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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