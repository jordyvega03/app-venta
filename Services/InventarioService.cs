using app_venta.Data;
using app_venta.Dtos;
using app_venta.Models;
using app_venta.Services.Impl;
using Microsoft.EntityFrameworkCore;

namespace app_venta.Services;

public class InventarioService : IInventarioService
{
    private readonly AppDbContext _db;
    public InventarioService(AppDbContext db) => _db = db;

    public async Task<List<Inventario>> GetAllAsync() =>
        await _db.Inventarios.ToListAsync();

    public async Task<Inventario?> GetByIdAsync(int id) =>
        await _db.Inventarios.FindAsync(id);

    public async Task<Inventario> CreateAsync(InventarioDto dto)
    {
        var inventario = new Inventario
        {
            NombreIngrediente = dto.NombreIngrediente,
            TipoIngrediente = dto.TipoIngrediente,
            Cantidad = dto.Cantidad,
            Unidad = dto.Unidad
        };
        _db.Inventarios.Add(inventario);
        await _db.SaveChangesAsync();
        return inventario;
    }

    public async Task<bool> UpdateAsync(int id, InventarioDto dto)
    {
        var existing = await _db.Inventarios.FindAsync(id);
        if (existing is null) return false;

        existing.NombreIngrediente = dto.NombreIngrediente;
        existing.TipoIngrediente = dto.TipoIngrediente;
        existing.Cantidad = dto.Cantidad;
        existing.Unidad = dto.Unidad;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _db.Inventarios.FindAsync(id);
        if (existing is null) return false;
        _db.Inventarios.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}