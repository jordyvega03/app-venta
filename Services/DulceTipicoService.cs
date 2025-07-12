using app_venta.Data;
using app_venta.Models;
using app_venta.Services.Impl;
using Microsoft.EntityFrameworkCore;

namespace app_venta.Services;

public class DulceTipicoService : IDulceTipicoService
{
    private readonly AppDbContext _db;
    public DulceTipicoService(AppDbContext db) => _db = db;

    public async Task<List<DulceTipico>> GetAllAsync() =>
        await _db.DulcesTipicos.ToListAsync();

    public async Task<DulceTipico?> GetByIdAsync(int id) =>
        await _db.DulcesTipicos.FindAsync(id);

    public async Task<DulceTipico> CreateAsync(DulceTipicoDto dto)
    {
        var dulce = new DulceTipico
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Tipo = dto.Tipo,
            TipoDulce = dto.TipoDulce,
            Empaque = dto.Empaque,
            CantidadEnCaja = dto.CantidadEnCaja
        };
        _db.DulcesTipicos.Add(dulce);
        await _db.SaveChangesAsync();
        return dulce;
    }

    public async Task<bool> UpdateAsync(int id, DulceTipicoDto dto)
    {
        var existing = await _db.DulcesTipicos.FindAsync(id);
        if (existing is null) return false;

        existing.Nombre = dto.Nombre;
        existing.Precio = dto.Precio;
        existing.Tipo = dto.Tipo;
        existing.TipoDulce = dto.TipoDulce;
        existing.Empaque = dto.Empaque;
        existing.CantidadEnCaja = dto.CantidadEnCaja;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _db.DulcesTipicos.FindAsync(id);
        if (existing is null) return false;
        _db.DulcesTipicos.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}