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

        routes.MapPost("/api/dulces", async ([FromServices] IDulceTipicoService service, [FromBody] DulceTipicoDto dto) =>
        {
            var dulce = await service.CreateAsync(dto);
            return Results.Created($"/api/dulces/{dulce.Id}", dulce);
        }).WithTags("Dulces");

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