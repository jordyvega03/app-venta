using System.ComponentModel.DataAnnotations;

namespace app_venta.Models;

public class Inventario
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NombreIngrediente { get; set; } = null!;

    [Required]
    public string TipoIngrediente { get; set; } = null!; // Carne, Guarnición, Dulce, Empaque, Carbón/Leña

    public decimal Cantidad { get; set; }

    [Required]
    public string Unidad { get; set; } = null!; // Libra, Unidad, Caja, etc.
}