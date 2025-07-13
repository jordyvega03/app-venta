using app_venta.Data;
using BCrypt.Net;
using app_venta.Dtos;
using app_venta.Services;
using Microsoft.EntityFrameworkCore;

namespace app_venta.Endpoints;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/login", async (
            LoginRequest request,
            AppDbContext db,
            TokenService tokenService) =>
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user is null)
                return Results.Unauthorized();

            Console.WriteLine("Hash en DB: " + user.PasswordHash);
            Console.WriteLine("Password enviada: " + request.Password);

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            Console.WriteLine("¿Contraseña válida? " + isPasswordValid);

            if (!isPasswordValid)
                return Results.Unauthorized();

            var token = tokenService.GenerateToken(user.Email, user.Role);

            return Results.Ok(new LoginResponse
            {
                Token = token
            });
        });

        app.MapGet("/secure", [Microsoft.AspNetCore.Authorization.Authorize]() =>
        {
            return Results.Ok("Accediste a una ruta protegida con JWT");
        });

        return app;
    }
}