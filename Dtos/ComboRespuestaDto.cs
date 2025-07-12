namespace app_venta.Dtos;

public class ComboRespuestaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public string TipoCombo { get; set; } = null!;
    public decimal Precio { get; set; }
    public string? Observaciones { get; set; }
    public List<string> Churrascos { get; set; } = new();
    public List<string> Dulces { get; set; } = new();
}
