using System.ComponentModel.DataAnnotations;

namespace app_venta.Models;

public class Guarnicion
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = null!; // Frijoles, Chirmol, etc.

    // Relación inversa
    public List<ChurrascoGuarnicion> ChurrascoGuarniciones { get; set; } = new();
}