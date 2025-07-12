using app_venta.Dtos;
using app_venta.Models;

namespace app_venta.Services.Impl;

public interface IGuarnicionService
{
    Task<List<Guarnicion>> GetAllAsync();
    Task<Guarnicion?> GetByIdAsync(int id);
    Task<Guarnicion> CreateAsync(GuarnicionDto dto);
    Task<bool> UpdateAsync(int id, GuarnicionDto dto);
    Task<bool> DeleteAsync(int id);
}