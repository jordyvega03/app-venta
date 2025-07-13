using app_venta.Data;
using app_venta.Dtos;
using app_venta.Models;
using app_venta.Services.Impl;
using Microsoft.EntityFrameworkCore;

namespace app_venta.Services;

public class ComboService : IComboService
{
    private readonly AppDbContext _db;
    public ComboService(AppDbContext db) => _db = db;

    public async Task<List<Combo>> GetAllAsync() =>
        await _db.Combos
            .Include(c => c.ComboChurrascos).ThenInclude(cc => cc.Churrasco)
            .Include(c => c.ComboDulces).ThenInclude(cd => cd.DulceTipico)
            .ToListAsync();

    public async Task<Combo?> GetByIdAsync(int id) =>
        await _db.Combos
            .Include(c => c.ComboChurrascos).ThenInclude(cc => cc.Churrasco)
            .Include(c => c.ComboDulces).ThenInclude(cd => cd.DulceTipico)
            .FirstOrDefaultAsync(c => c.Id == id);

    // Ahora recibe Combo directamente (no ComboDto)
    public async Task<Combo> CreateAsync(ComboDto dto)
    {
        var combo = new Combo
        {
            Nombre = dto.Nombre,
            Tipo = dto.Tipo,
            TipoCombo = dto.TipoCombo,
            Precio = dto.Precio,
            Observaciones = dto.Observaciones,
            UrlImagen = dto.UrlImagen,
            ComboChurrascos = dto.ChurrascoIds.Select(cid => new ComboChurrasco { ChurrascoId = cid }).ToList(),
            ComboDulces = dto.DulceIds.Select(did => new ComboDulce { DulceTipicoId = did }).ToList()
        };
        _db.Combos.Add(combo);
        await _db.SaveChangesAsync();
        return combo;
    }


    public async Task<bool> UpdateAsync(int id, ComboDto dto)
    {
        var combo = await _db.Combos
            .Include(c => c.ComboChurrascos)
            .Include(c => c.ComboDulces)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (combo == null) return false;

        combo.Nombre = dto.Nombre;
        combo.Precio = dto.Precio;
        combo.Tipo = dto.Tipo;
        combo.TipoCombo = dto.TipoCombo;
        combo.Observaciones = dto.Observaciones;
        combo.UrlImagen = dto.UrlImagen;

        // Actualiza los churrascos
        combo.ComboChurrascos.Clear();
        foreach (var cid in dto.ChurrascoIds)
            combo.ComboChurrascos.Add(new ComboChurrasco { ChurrascoId = cid, ComboId = id });

        // Actualiza los dulces
        combo.ComboDulces.Clear();
        foreach (var did in dto.DulceIds)
            combo.ComboDulces.Add(new ComboDulce { DulceTipicoId = did, ComboId = id });

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var combo = await _db.Combos.FindAsync(id);
        if (combo is null) return false;
        _db.Combos.Remove(combo);
        await _db.SaveChangesAsync();
        return true;
    }
}