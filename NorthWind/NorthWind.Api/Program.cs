using Microsoft.EntityFrameworkCore;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Interfaces;
using NorthWind.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Dependencias del contexto //

builder.Services.AddDbContext<NorthWindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthWindContext")));


// Dependencias de los repositorios //

builder.Services.AddTransient<IOrderDetailsRepository, OrderDetailsRepository>();
builder.Services.AddTransient<ICategoriesRepositry, CategoriesRepository>();

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
