using app_venta.Models;

namespace app_venta.Services.Impl;

public interface IChurrascoService
{
    Task<List<Churrasco>> GetAllAsync();
    Task<Churrasco?> GetByIdAsync(int id);
    Task<Churrasco> CreateAsync(Churrasco churrasco);
    Task<bool> UpdateAsync(int id, Churrasco churrasco);
    Task<bool> DeleteAsync(int id);
}