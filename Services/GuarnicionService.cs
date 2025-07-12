using app_venta.Data;
using app_venta.Dtos;
using app_venta.Models;
using app_venta.Services.Impl;
using Microsoft.EntityFrameworkCore;

namespace app_venta.Services;

public class GuarnicionService : IGuarnicionService
{
    private readonly AppDbContext _db;

    public GuarnicionService(AppDbContext db) => _db = db;

    public async Task<List<Guarnicion>> GetAllAsync() =>
        await _db.Guarniciones.ToListAsync();

    public async Task<Guarnicion?> GetByIdAsync(int id) =>
        await _db.Guarniciones.FindAsync(id);

    public async Task<Guarnicion> CreateAsync(GuarnicionDto dto)
    {
        var guarnicion = new Guarnicion
        {
            Nombre = dto.Nombre
        };
        _db.Guarniciones.Add(guarnicion);
        await _db.SaveChangesAsync();
        return guarnicion;
    }

    public async Task<bool> UpdateAsync(int id, GuarnicionDto dto)
    {
        var existing = await _db.Guarniciones.FindAsync(id);
        if (existing is null) return false;

        existing.Nombre = dto.Nombre;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _db.Guarniciones.FindAsync(id);
        if (existing is null) return false;

        _db.Guarniciones.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}