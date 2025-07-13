using System.ComponentModel.DataAnnotations;

namespace app_venta.Dtos;

public class ComboDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El tipo es obligatorio.")]
    [StringLength(50, ErrorMessage = "El tipo no puede exceder los 50 caracteres.")]
    public string Tipo { get; set; } = null!;

    [Required(ErrorMessage = "El tipo de combo es obligatorio.")]
    [StringLength(50, ErrorMessage = "El tipo de combo no puede exceder los 50 caracteres.")]
    public string TipoCombo { get; set; } = null!;

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
    public decimal Precio { get; set; }

    [StringLength(255, ErrorMessage = "Las observaciones no pueden exceder los 255 caracteres.")]
    public string? Observaciones { get; set; }
    
    [Url(ErrorMessage = "Debe proporcionar una URL válida.")]
    public string? UrlImagen { get; set; }

    // IDs de los churrascos y dulces que incluirá el combo
    public List<int> ChurrascoIds { get; set; } = new();
    public List<int> DulceIds { get; set; } = new();
}