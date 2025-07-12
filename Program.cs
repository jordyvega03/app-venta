// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using app_venta.Data;
using app_venta.Endpoints;
using app_venta.Services;
using app_venta.Services.Impl; // <-- Agrega esto

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// REGISTRA TU SERVICIO AQUÍ
builder.Services.AddScoped<IChurrascoService, ChurrascoService>();
builder.Services.AddScoped<IGuarnicionService, GuarnicionService>();
builder.Services.AddScoped<IDulceTipicoService, DulceTipicoService>();
builder.Services.AddScoped<IComboService, ComboService>();
builder.Services.AddScoped<IInventarioService, InventarioService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.RoutePrefix = "swagger";
    });
}

// Endpoints
app.MapChurrascosEndpoints();
app.MapGuarnicionesEndpoints();
app.MapDulcesTipicosEndpoints();
app.MapCombosEndpoints();
app.MapInventarioEndpoints();

app.MapGet("/", () => "¡Hola, mundo!");

app.Run();

