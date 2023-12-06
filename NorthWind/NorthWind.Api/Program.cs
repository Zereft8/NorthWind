using Microsoft.EntityFrameworkCore;
using NorthWind.Infrastructure.Context;
using NorthWind.Ioc.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Dependencias del contexto //


builder.Services.AddDbContext<NorthWindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthWindContext")));


// Dependencias del modulo customers //

builder.Services.AddCustomerDependency();

// Dependencias de los app service //

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
