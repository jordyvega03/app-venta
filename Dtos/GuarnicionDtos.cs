using System.ComponentModel.DataAnnotations;

namespace app_venta.Dtos;

// DTO para crear o actualizar guarniciones
public class GuarnicionDto
{
    [Required(ErrorMessage = "El nombre de la guarnición es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
    public string Nombre { get; set; } = null!;
}