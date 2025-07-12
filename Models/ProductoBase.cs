using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_venta.Models;

public abstract class ProductoBase
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "decimal(10,2)")]
    public decimal Precio { get; set; }

    [Required, MaxLength(50)]
    public string Tipo { get; set; } = null!; // Churrasco, Dulce, Combo
}
