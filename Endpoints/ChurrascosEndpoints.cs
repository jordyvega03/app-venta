using app_venta.Dtos;
using Microsoft.AspNetCore.Mvc;
using app_venta.Models;
using app_venta.Services.Impl;

namespace app_venta.Endpoints;

public static class ChurrascosEndpoints
{
    public static IEndpointRouteBuilder MapChurrascosEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/churrascos", async ([FromServices] IChurrascoService service) =>
        {
            var result = await service.GetAllAsync();
            return Results.Ok(result);
        })
        .WithTags("Churrascos");

        routes.MapGet("/api/churrascos/{id}", async ([FromServices] IChurrascoService service, int id) =>
        {
            var result = await service.GetByIdAsync(id);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        })
        .WithTags("Churrascos");

        routes.MapPost("/api/churrascos/upload", async (
                [FromForm] ChurrascoUploadDto dto,
                IChurrascoService service
            ) =>
            {
                string? imageUrl = null;

                if (dto.Imagen is not null && dto.Imagen.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "upload");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(dto.Imagen.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    await dto.Imagen.CopyToAsync(stream);

                    imageUrl = $"/upload/{uniqueFileName}";
                }

                var churrasco = new Churrasco
                {
                    Nombre = dto.Nombre,
                    Precio = dto.Precio,
                    Tipo = dto.Tipo,
                    TipoCarne = dto.TipoCarne,
                    Termino = dto.Termino,
                    Tamaño = dto.Tamaño,
                    Porciones = dto.Porciones,
                    UrlImagen = imageUrl
                };

                var nuevo = await service.CreateAsync(churrasco);
                return Results.Created($"/api/churrascos/{nuevo.Id}", nuevo);
            })
            .Accepts<ChurrascoUploadDto>("multipart/form-data")
            .WithTags("Churrascos");

        routes.MapPut("/api/churrascos/{id}", async ([FromServices] IChurrascoService service, int id, [FromBody] ChurrascoCreateDto dto) =>
        {
            var churrasco = new Churrasco
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Tipo = dto.Tipo,
                TipoCarne = dto.TipoCarne,
                Termino = dto.Termino,
                Tamaño = dto.Tamaño,
                Porciones = dto.Porciones,
                ChurrascoGuarniciones = dto.ChurrascoGuarniciones.Select(g => new ChurrascoGuarnicion
                {
                    GuarnicionId = g.GuarnicionId,
                    Cantidad = g.Cantidad
                }).ToList()
            };

            var updated = await service.UpdateAsync(id, churrasco);
            return updated ? Results.NoContent() : Results.NotFound();
        })
        .WithTags("Churrascos");

        routes.MapDelete("/api/churrascos/{id}", async ([FromServices] IChurrascoService service, int id) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .WithTags("Churrascos");

        return routes;
    }
}
