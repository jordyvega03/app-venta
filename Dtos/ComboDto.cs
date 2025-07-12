namespace app_venta.Dtos;

public class ComboDto
{
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
    public string Tipo { get; set; } = null!;
    public string TipoCombo { get; set; } = null!;
    public string? Observaciones { get; set; }

    // IDs de los churrascos y dulces que incluirá el combo
    public List<int> ChurrascoIds { get; set; } = new();
    public List<int> DulceIds { get; set; } = new();
}