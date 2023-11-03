using Microsoft.EntityFrameworkCore;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Interfaces;
using NorthWind.Infrastructure.Repositories;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Agregar dependencia del contexto
builder.Services.AddDbContext<NorthWindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthWindContext")));
//dependencia de los repositorios

builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();

//DEpendencia de los app services

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
