using System.ComponentModel.DataAnnotations;

namespace app_venta.Models;

public class Churrasco : ProductoBase
{
    [Required]
    public string TipoCarne { get; set; } = null!; // Puyazo, Culotte, Costilla

    [Required]
    public string Termino { get; set; } = null!; // Medio, Tres Cuartos, Bien Cocido

    [Required]
    public string Tamaño { get; set; } = null!; // Individual, Familiar

    public int Porciones { get; set; }

    // Relación con Guarnición
    public List<ChurrascoGuarnicion> ChurrascoGuarniciones { get; set; } = new();
}