using app_venta.Models;

namespace app_venta.Services.Impl;

public interface IDulceTipicoService
{
    Task<List<DulceTipico>> GetAllAsync();
    Task<DulceTipico?> GetByIdAsync(int id);
    Task<DulceTipico> CreateAsync(DulceTipicoDto dto);
    Task<bool> UpdateAsync(int id, DulceTipicoDto dto);
    Task<bool> DeleteAsync(int id);
}