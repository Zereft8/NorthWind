using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Repository;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Agregar Dependencias del Contexto//
builder.Services.AddDbContext<NorthWindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthWindContext")));

//Agregar Dependencias de los Repositorios//
builder.Services.AddTransient<ISuppliersRepository, SuppliersRepository>();


//Agregar Dependencias de los App Services//


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
