using app_venta.Data;
using app_venta.Dtos;
using app_venta.Models;
using app_venta.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app_venta.Endpoints;

public static class GuarnicionesEndpoints
{
    public static IEndpointRouteBuilder MapGuarnicionesEndpoints(this IEndpointRouteBuilder routes)
    {
        // GET: Todas las guarniciones
        routes.MapGet("/api/guarniciones", async ([FromServices] IGuarnicionService service) =>
        {
            var result = await service.GetAllAsync();
            return Results.Ok(result);
        }).WithTags("Guarniciones");

        // GET: Guarnición por ID
        routes.MapGet("/api/guarniciones/{id}", async ([FromServices] IGuarnicionService service, int id) =>
        {
            var guarnicion = await service.GetByIdAsync(id);
            return guarnicion is not null ? Results.Ok(guarnicion) : Results.NotFound();
        }).WithTags("Guarniciones");

        // POST: Crear guarnición
        routes.MapPost("/api/guarniciones", async ([FromServices] IGuarnicionService service, [FromBody] GuarnicionDto dto) =>
        {
            var guarnicion = await service.CreateAsync(dto);
            return Results.Created($"/api/guarniciones/{guarnicion.Id}", guarnicion);
        }).WithTags("Guarniciones");

        // PUT: Editar guarnición
        routes.MapPut("/api/guarniciones/{id}", async ([FromServices] IGuarnicionService service, int id, [FromBody] GuarnicionDto dto) =>
        {
            var updated = await service.UpdateAsync(id, dto);
            return updated ? Results.NoContent() : Results.NotFound();
        }).WithTags("Guarniciones");

        // DELETE: Eliminar guarnición
        routes.MapDelete("/api/guarniciones/{id}", async ([FromServices] IGuarnicionService service, int id) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        }).WithTags("Guarniciones");

        return routes;
    }
}