namespace app_venta.Dtos;

public class InventarioDto
{
    public string NombreIngrediente { get; set; } = null!;
    public string TipoIngrediente { get; set; } = null!;
    public decimal Cantidad { get; set; }
    public string Unidad { get; set; } = null!;
}