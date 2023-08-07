using BSATask.DAL.Context;
using BSATask.WebAPI.ServiceExtensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Call the custom service registration method
builder.Services.RegisterCustomServices();
builder.Services.RegisterAutoMapper();
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
.Build();


var migrationAssembly = typeof(BSATaskContext).Assembly.GetName().Name;
builder.Services.AddDbContext<BSATaskContext>(options =>
    options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], opt => opt.MigrationsAssembly(migrationAssembly)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
