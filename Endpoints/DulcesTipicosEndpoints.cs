using app_venta.Models;
using app_venta.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace app_venta.Endpoints;

public static class DulcesTipicosEndpoints
{
    public static IEndpointRouteBuilder MapDulcesTipicosEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/dulces", async ([FromServices] IDulceTipicoService service) =>
        {
            var result = await service.GetAllAsync();
            return Results.Ok(result);
        }).WithTags("Dulces");

        routes.MapGet("/api/dulces/{id}", async ([FromServices] IDulceTipicoService service, int id) =>
        {
            var dulce = await service.GetByIdAsync(id);
            return dulce is not null ? Results.Ok(dulce) : Results.NotFound();
        }).WithTags("Dulces");

        routes.MapPost("/api/dulces/upload", async (HttpRequest request, IWebHostEnvironment env) =>
            {
                var form = await request.ReadFormAsync();
                var file = form.Files.GetFile("imagen");

                if (file is null || file.Length == 0)
                    return Results.BadRequest("Debe proporcionar una imagen válida.");

                var uploadsPath = Path.Combine(env.WebRootPath ?? "wwwroot", "upload");
                Directory.CreateDirectory(uploadsPath);

                var extension = Path.GetExtension(file.FileName);
                var fileName = $"dulce_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                var filePath = Path.Combine(uploadsPath, fileName);

                await using var stream = File.Create(filePath);
                await file.CopyToAsync(stream);

                var url = $"http://localhost:5000/upload/{fileName}";
                return Results.Ok(new { url });
            })
            .WithTags("Dulces");

        routes.MapPut("/api/dulces/{id}", async ([FromServices] IDulceTipicoService service, int id, [FromBody] DulceTipicoDto dto) =>
        {
            var updated = await service.UpdateAsync(id, dto);
            return updated ? Results.NoContent() : Results.NotFound();
        }).WithTags("Dulces");

        routes.MapDelete("/api/dulces/{id}", async ([FromServices] IDulceTipicoService service, int id) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        }).WithTags("Dulces");

        return routes;
    }
}