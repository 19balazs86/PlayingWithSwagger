﻿using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace PlayingWithSwagger
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Demo API", Version = "1.0", Description = "A simple example ASP.NET Core Web API" });
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PlayingWithSwagger.xml"));
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();

      app.UseSwagger();

      // http://localhost:5000/swagger/index.html
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Demo API (V 1.0)"));

      app.UseRouting();

      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
  }
}
