// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using app_venta.Data;
using app_venta.Endpoints;
using app_venta.Extensions;
using app_venta.Services;
using app_venta.Services.Impl;
using Microsoft.Extensions.FileProviders; // <-- Agrega esto

// Crear el builder
var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// REGISTRA TUS SERVICIOS AQUÍ
builder.Services.AddScoped<IChurrascoService, ChurrascoService>();
builder.Services.AddScoped<IGuarnicionService, GuarnicionService>();
builder.Services.AddScoped<IDulceTipicoService, DulceTipicoService>();
builder.Services.AddScoped<IComboService, ComboService>();
builder.Services.AddScoped<IInventarioService, InventarioService>();

// Servicio para generar tokens JWT
builder.Services.AddScoped<TokenService>();

// JWT y autorización
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization();

// Swagger y Endpoints API Explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS: SOLO permite el frontend de Vite/React
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173", "http://localhost:5000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// ¡Activa la política CORS aquí!
app.UseCors("DevCors");

// Activar middlewares de autenticación/autorización
app.UseAuthentication();
app.UseAuthorization();

// Swagger solo en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.RoutePrefix = "swagger";
    });
}

// Mapear endpoints
app.MapChurrascosEndpoints();
app.MapGuarnicionesEndpoints();
app.MapDulcesTipicosEndpoints();
app.MapCombosEndpoints();
app.MapInventarioEndpoints();
app.MapAuthEndpoints();

// Endpoint de prueba
app.MapGet("/", () => "¡Hola, mundo!");

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "upload")),
    RequestPath = "/upload"
});

app.UseStaticFiles();

app.Run();

