using app_venta.Dtos;
using app_venta.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace app_venta.Endpoints;

public static class InventarioEndpoints
{
    public static IEndpointRouteBuilder MapInventarioEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/inventario", async ([FromServices] IInventarioService service) =>
        {
            var result = await service.GetAllAsync();
            return Results.Ok(result);
        }).WithTags("Inventario");

        routes.MapGet("/api/inventario/{id}", async ([FromServices] IInventarioService service, int id) =>
        {
            var inventario = await service.GetByIdAsync(id);
            return inventario is not null ? Results.Ok(inventario) : Results.NotFound();
        }).WithTags("Inventario");

        routes.MapPost("/api/inventario", async ([FromServices] IInventarioService service, [FromBody] InventarioDto dto) =>
        {
            var inventario = await service.CreateAsync(dto);
            return Results.Created($"/api/inventario/{inventario.Id}", inventario);
        }).WithTags("Inventario");

        routes.MapPut("/api/inventario/{id}", async ([FromServices] IInventarioService service, int id, [FromBody] InventarioDto dto) =>
        {
            var updated = await service.UpdateAsync(id, dto);
            return updated ? Results.NoContent() : Results.NotFound();
        }).WithTags("Inventario");

        routes.MapDelete("/api/inventario/{id}", async ([FromServices] IInventarioService service, int id) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        }).WithTags("Inventario");

        return routes;
    }
}