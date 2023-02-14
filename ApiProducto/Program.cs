//using Datos.DataContext;

using Datos.DataContext;
using Datos.Repositories;
using Datos.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Negocio.Services;
using Negocio.Services.Contracts;
using System.Data.Common;
using System.Data;
using Microsoft.OpenApi.Models;
//using Datos.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbapiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDB")));
builder.Services.AddTransient(typeof(IGenericRepository), typeof(GenericRepository));
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Api Producto",
            Version = "v1",
            Description = "Web API para Registro, busqueda y eliminacion de Producto.",
            Contact = new OpenApiContact
            {
                Name = "Pedro Polo",
                Email = "ppolot@gmail.com"
            }
        });
});



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
