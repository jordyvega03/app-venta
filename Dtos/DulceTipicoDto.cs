using System.ComponentModel.DataAnnotations;

namespace app_venta.Models;

public class DulceTipicoDto
{
    [Required(ErrorMessage = "El nombre del dulce es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
    public string Nombre { get; set; } = null!;

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "El tipo es obligatorio.")]
    [StringLength(50, ErrorMessage = "El tipo no puede exceder los 50 caracteres.")]
    public string Tipo { get; set; } = null!;

    [Required(ErrorMessage = "El tipo de dulce es obligatorio.")]
    [StringLength(50, ErrorMessage = "El tipo de dulce no puede exceder los 50 caracteres.")]
    public string TipoDulce { get; set; } = null!;

    [Required(ErrorMessage = "El empaque es obligatorio.")]
    [StringLength(50, ErrorMessage = "El empaque no puede exceder los 50 caracteres.")]
    public string Empaque { get; set; } = null!;

    [Range(0, int.MaxValue, ErrorMessage = "La cantidad en caja no puede ser negativa.")]
    public int CantidadEnCaja { get; set; }
    
    public string? UrlImagen { get; set; }
}