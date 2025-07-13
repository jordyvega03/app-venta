using app_venta.Dtos;
using app_venta.Models;
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
        }).WithTags("Combos");

        routes.MapGet("/api/combos/{id}", async ([FromServices] IComboService service, int id) =>
        {
            var combo = await service.GetByIdAsync(id);
            return combo is not null ? Results.Ok(combo) : Results.NotFound();
        }).WithTags("Combos");

        // POST que recibe DTO y crea Combo
        routes.MapPost("/api/combos", async ([FromServices] IComboService service, [FromBody] ComboDto dto) =>
        {
            var combo = new Combo
            {
                Nombre = dto.Nombre,
                Tipo = dto.Tipo,
                TipoCombo = dto.TipoCombo,
                Precio = dto.Precio,
                Observaciones = dto.Observaciones,
                UrlImagen = dto.UrlImagen,
                ComboChurrascos = dto.ChurrascoIds.Select(id => new ComboChurrasco { ChurrascoId = id }).ToList(),
                ComboDulces = dto.DulceIds.Select(id => new ComboDulce { DulceTipicoId = id }).ToList()
            };

            var nuevo = await service.CreateAsync(dto);
            return Results.Created($"/api/combos/{nuevo.Id}", nuevo);
        })
        .Accepts<ComboDto>("application/json")
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