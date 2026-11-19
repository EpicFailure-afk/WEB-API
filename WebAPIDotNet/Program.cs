
using Microsoft.EntityFrameworkCore;
using WebAPIDotNet.Models;
using WebAPIDotNet.Repositories;

namespace WebAPIDotNet
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();

      builder.Services.AddDbContext<Context>(options =>
      {
        options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
      });

      builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
      
      // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
      builder.Services.AddOpenApi();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.MapOpenApi();
      }

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
