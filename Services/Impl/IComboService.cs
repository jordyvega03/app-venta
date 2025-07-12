using app_venta.Dtos;
using app_venta.Models;

namespace app_venta.Services.Impl;

public interface IComboService
{
    Task<List<Combo>> GetAllAsync();
    Task<Combo?> GetByIdAsync(int id);
    Task<Combo> CreateAsync(ComboDto dto);
    Task<bool> UpdateAsync(int id, ComboDto dto);
    Task<bool> DeleteAsync(int id);
}