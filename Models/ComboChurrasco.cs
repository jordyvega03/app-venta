using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_venta.Models;

public class ComboChurrasco
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Combo")]
    public int ComboId { get; set; }
    public Combo Combo { get; set; } = null!;

    [ForeignKey("Churrasco")]
    public int ChurrascoId { get; set; }
    public Churrasco Churrasco { get; set; } = null!;

    public int Cantidad { get; set; }
}