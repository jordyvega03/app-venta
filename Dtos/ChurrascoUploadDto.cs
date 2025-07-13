using System.ComponentModel.DataAnnotations;

namespace app_venta.Dtos;

public class ChurrascoUploadDto
{
    [Required]
    public string Nombre { get; set; } = null!;

    [Required]
    public decimal Precio { get; set; }

    [Required]
    public string Tipo { get; set; } = null!;

    [Required]
    public string TipoCarne { get; set; } = null!;

    [Required]
    public string Termino { get; set; } = null!;

    [Required]
    public string Tamaño { get; set; } = null!;

    [Required]
    public int Porciones { get; set; }

    public IFormFile? Imagen { get; set; }
}
