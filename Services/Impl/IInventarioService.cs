using app_venta.Dtos;
using app_venta.Models;

namespace app_venta.Services.Impl;

public interface IInventarioService
{
    Task<List<Inventario>> GetAllAsync();
    Task<Inventario?> GetByIdAsync(int id);
    Task<Inventario> CreateAsync(InventarioDto dto);
    Task<bool> UpdateAsync(int id, InventarioDto dto);
    Task<bool> DeleteAsync(int id);
}