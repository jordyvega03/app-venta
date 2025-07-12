using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_venta.Models;

public class ComboDulce
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Combo")]
    public int ComboId { get; set; }
    public Combo Combo { get; set; } = null!;

    [ForeignKey("DulceTipico")]
    public int DulceTipicoId { get; set; }
    public DulceTipico DulceTipico { get; set; } = null!;

    public int Cantidad { get; set; }
}