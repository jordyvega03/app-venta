using System.ComponentModel.DataAnnotations;

namespace app_venta.Models;

public class DulceTipico : ProductoBase
{
    [Required]
    public string TipoDulce { get; set; } = null!; // Canillitas, Pepitoria, etc.

    [Required]
    public string Empaque { get; set; } = null!; // Unidad, Caja

    public int CantidadEnCaja { get; set; }
}