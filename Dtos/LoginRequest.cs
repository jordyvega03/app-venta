using System.ComponentModel.DataAnnotations;

namespace app_venta.Dtos;

public class LoginRequest
{
    [Required(ErrorMessage = "Se requiere un email valido.")]
    public string Email { get; set; } = default!;
    
    [Required(ErrorMessage = "Se requiere una contraseña valida.")]
    public string Password { get; set; } = default!;
}