using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace PlayingWithSwagger;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;

        // Add services to the container
        {
            services.AddControllers();

            services.AddSwaggerGen(configureSwagger);
        }

        WebApplication app = builder.Build();

        // Configure the request pipeline
        {
            app.UseSwagger();

            // http://localhost:5000/swagger/index.html
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Demo API (V 1.0)"));

            app.UseRouting();

            app.MapControllers();
        }

        app.Run();
    }

    private static void configureSwagger(SwaggerGenOptions options)
    {
        var info = new OpenApiInfo { Title = "Demo API", Version = "1.0", Description = "A simple Web API example" };

        options.SwaggerDoc("v1.0", info);

        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PlayingWithSwagger.xml"));
    }
}
