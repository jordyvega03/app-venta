using System.ComponentModel.DataAnnotations;

namespace app_venta.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string Role { get; set; } = "User";
}