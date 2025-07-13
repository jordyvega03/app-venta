namespace app_venta.Dtos;

using System.ComponentModel.DataAnnotations;

public class InventarioDto
{
    [Required(ErrorMessage = "El nombre del ingrediente es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string NombreIngrediente { get; set; } = null!;

    [Required(ErrorMessage = "El tipo de ingrediente es obligatorio.")]
    public string TipoIngrediente { get; set; } = null!;

    [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
    public decimal Cantidad { get; set; }

    [Required(ErrorMessage = "La unidad es obligatoria.")]
    [StringLength(50)]
    public string Unidad { get; set; } = null!;
}