using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_venta.Models;

public class ChurrascoGuarnicion
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Churrasco")]
    public int ChurrascoId { get; set; }
    public Churrasco Churrasco { get; set; } = null!;

    [ForeignKey("Guarnicion")]
    public int GuarnicionId { get; set; }
    public Guarnicion Guarnicion { get; set; } = null!;

    public int Cantidad { get; set; } // Incluye porciones extra
}