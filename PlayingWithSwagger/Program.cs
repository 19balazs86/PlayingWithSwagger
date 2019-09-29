using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace PlayingWithSwagger
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      return Host
        .CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webHostBuilder =>
          webHostBuilder
            .UseStartup<Startup>());
    }
  }
}
