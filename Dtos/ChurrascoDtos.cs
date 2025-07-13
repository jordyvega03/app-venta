using System.ComponentModel.DataAnnotations;

namespace app_venta.Dtos;

// DTO para crear o actualizar churrascos
public class ChurrascoCreateDto
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no debe exceder los 100 caracteres.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "El tipo es obligatorio.")]
    public string Tipo { get; set; } = null!;

    [Required(ErrorMessage = "El tipo de carne es obligatorio.")]
    public string TipoCarne { get; set; } = null!;

    [Required(ErrorMessage = "El término de cocción es obligatorio.")]
    public string Termino { get; set; } = null!;

    [Required(ErrorMessage = "El tamaño es obligatorio.")]
    public string Tamaño { get; set; } = null!;

    [Required(ErrorMessage = "Debe especificar la cantidad de porciones.")]
    [Range(1, 20, ErrorMessage = "Las porciones deben ser entre 1 y 20.")]
    public int Porciones { get; set; }
    
    [Url(ErrorMessage = "Debe proporcionar una URL válida.")]
    public string? UrlImagen { get; set; }

    [MinLength(1, ErrorMessage = "Debe incluir al menos una guarnición.")]
    public List<ChurrascoGuarnicionDto> ChurrascoGuarniciones { get; set; } = new();
}

// DTO para la relación con guarniciones
public class ChurrascoGuarnicionDto
{
    [Required(ErrorMessage = "Debe especificar el ID de la guarnición.")]
    [Range(1, int.MaxValue, ErrorMessage = "El ID de la guarnición debe ser mayor a cero.")]
    public int GuarnicionId { get; set; }

    [Required(ErrorMessage = "La cantidad es obligatoria.")]
    [Range(1, 10, ErrorMessage = "La cantidad de guarnición debe ser entre 1 y 10.")]
    public int Cantidad { get; set; }
}