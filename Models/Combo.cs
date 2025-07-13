using System.ComponentModel.DataAnnotations;

namespace app_venta.Models;

public class Combo : ProductoBase
{
    [Required]
    public string TipoCombo { get; set; } = null!; // Familiar, Evento, Personalizado

    public string? Observaciones { get; set; }
    
    public string? UrlImagen { get; set; }

    // Relación muchos-a-muchos con churrascos y dulces
    public List<ComboChurrasco> ComboChurrascos { get; set; } = new();
    public List<ComboDulce> ComboDulces { get; set; } = new();
}