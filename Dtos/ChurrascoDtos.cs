namespace app_venta.Dtos;

// DTO para crear o actualizar churrascos
public class ChurrascoCreateDto
{
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
    public string Tipo { get; set; } = null!;
    public string TipoCarne { get; set; } = null!;
    public string Termino { get; set; } = null!;
    public string Tamaño { get; set; } = null!;
    public int Porciones { get; set; }
    public List<ChurrascoGuarnicionDto> ChurrascoGuarniciones { get; set; } = new();
}

// DTO para la relación con guarniciones
public class ChurrascoGuarnicionDto
{
    public int GuarnicionId { get; set; }
    public int Cantidad { get; set; }
}