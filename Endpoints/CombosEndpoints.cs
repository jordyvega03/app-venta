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

        routes.MapPost("/api/combos", async ([FromServices] IComboService service, [FromBody] ComboDto dto) =>
            {
                var combo = await service.CreateAsync(dto);
                // Construye una respuesta DTO simple para no serializar ciclos
                var result = new {
                    combo.Id,
                    combo.Nombre,
                    combo.Tipo,
                    combo.TipoCombo,
                    combo.Precio,
                    combo.Observaciones
                    // puedes agregar ids de churrascos y dulces si quieres
                };
                return Results.Created($"/api/combos/{combo.Id}", result);
            })
            .WithTags("Combos");

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