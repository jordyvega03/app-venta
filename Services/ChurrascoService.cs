using app_venta.Data;
using app_venta.Models;
using app_venta.Services.Impl;
using Microsoft.EntityFrameworkCore;

namespace app_venta.Services;

public class ChurrascoService : IChurrascoService
{
    private readonly AppDbContext _db;

    public ChurrascoService(AppDbContext db) => _db = db;

    public async Task<List<Churrasco>> GetAllAsync() =>
        await _db.Churrascos.ToListAsync();

    public async Task<Churrasco?> GetByIdAsync(int id) =>
        await _db.Churrascos.FindAsync(id);

    public async Task<Churrasco> CreateAsync(Churrasco churrasco)
    {
        _db.Churrascos.Add(churrasco);
        await _db.SaveChangesAsync();
        return churrasco;
    }

    public async Task<bool> UpdateAsync(int id, Churrasco churrasco)
    {
        var existing = await _db.Churrascos.FindAsync(id);
        if (existing == null) return false;

        // Actualiza propiedades relevantes
        existing.TipoCarne = churrasco.TipoCarne;
        existing.Termino = churrasco.Termino;
        existing.Tamaño = churrasco.Tamaño;
        existing.Porciones = churrasco.Porciones;
        existing.ChurrascoGuarniciones = churrasco.ChurrascoGuarniciones;
        existing.Porciones = churrasco.Porciones;
        existing.Nombre = churrasco.Nombre;
        existing.Precio = churrasco.Precio;
        existing.Tipo = churrasco.Tipo;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _db.Churrascos.FindAsync(id);
        if (existing == null) return false;

        _db.Churrascos.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}