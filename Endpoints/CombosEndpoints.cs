using app_venta.Dtos;
using app_venta.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace app_venta.Endpoints;

public static class CombosEndpoints
{
    public static IEndpointRouteBuilder MapCombosEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/combos", async ([FromServices] IComboService service) =>
            {
                var combos = await service.GetAllAsync();
                // Mapea combos a DTOs para romper el ciclo
                var dtos = combos.Select(combo => new ComboRespuestaDto
                {
                    Id = combo.Id,
                    Nombre = combo.Nombre,
                    Tipo = combo.Tipo,
                    TipoCombo = combo.TipoCombo,
                    Precio = combo.Precio,
                    Observaciones = combo.Observaciones,
                    UrlImagen = combo.UrlImagen,
                    Churrascos = combo.ComboChurrascos.Select(cc => cc.Churrasco.Nombre).ToList(),
                    Dulces = combo.ComboDulces.Select(cd => cd.DulceTipico.Nombre).ToList()
                }).ToList();

                return Results.Ok(dtos);
            })
            .WithTags("Combos");


        routes.MapGet("/api/combos/{id}", async ([FromServices] IComboService service, int id) =>
        {
            var combo = await service.GetByIdAsync(id);
            return combo is not null ? Results.Ok(combo) : Results.NotFound();
        }).WithTags("Combos");

        routes.MapPost("/api/combos/upload", async (HttpRequest request) =>
            {
                var form = await request.ReadFormAsync();
                var file = form.Files.GetFile("file");

                if (file == null || file.Length == 0)
                    return Results.BadRequest("Archivo no válido.");

                var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "upload");
                if (!Directory.Exists(uploadsPath))
                    Directory.CreateDirectory(uploadsPath);

                var fileName = $"combo_{DateTime.Now:yyyyMMddHHmmss}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(uploadsPath, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                var url = $"http://localhost:5000/upload/{fileName}";
                return Results.Ok(new { url });
            })
            .WithTags("Combos")
            .DisableAntiforgery(); // Para evitar error en Swagger

        routes.MapPut("/api/combos/{id}", async ([FromServices] IComboService service, int id, [FromBody] ComboDto dto) =>
        {
            var updated = await service.UpdateAsync(id, dto);
            return updated ? Results.NoContent() : Results.NotFound();
        }).WithTags("Combos");

        routes.MapDelete("/api/combos/{id}", async ([FromServices] IComboService service, int id) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        }).WithTags("Combos");

        return routes;
    }
}