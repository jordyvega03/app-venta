using app_venta.Data;
using app_venta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace app_venta.Test;

class InsertTestUser
{
    static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder();

        // Cargar configuración desde appsettings.json
        builder.Configuration.AddJsonFile("appsettings.json");

        // Configurar el DbContext
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        using var host = builder.Build();
        using var scope = host.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // Verificar si el usuario ya existe
        var email = args.Length > 0 ? args[0] : "admin@example.com";
        var password = args.Length > 1 ? args[1] : "123456";

        // Verificar si ya existe
        if (await db.Users.AnyAsync(u => u.Email == email))
        {
            Console.WriteLine($"Ya existe un usuario con el email: {email}");
            return;
        }

        var hash = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new User
        {
            Email = email,
            PasswordHash = hash,
            Role = "Admin"
        };

        db.Users.Add(user);
        await db.SaveChangesAsync();

        Console.WriteLine($"Usuario '{user.Email}' creado correctamente con rol '{user.Role}'.");
    }
}