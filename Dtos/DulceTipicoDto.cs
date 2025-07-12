namespace app_venta.Models;

public class DulceTipicoDto
{
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
    public string Tipo { get; set; } = null!;  // Opcional, si usas 'Tipo' en ProductoBase
    public string TipoDulce { get; set; } = null!;
    public string Empaque { get; set; } = null!;
    public int CantidadEnCaja { get; set; }
}