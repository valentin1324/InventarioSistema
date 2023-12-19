using System;
using System.ComponentModel.DataAnnotations;

public class Producto
{
    [Key]
    public int ProductoId { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(50)]
    public string Codigo { get; set; }

    [Required]
    public DateTime FechaVencimiento { get; set; }

    [Required]
    [StringLength(200)]
    public string Ubicacion { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public decimal Costo { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public decimal PrecioVenta { get; set; }

    [Required]
    public int Stock { get; set; }
    public string Proveedor { get; set; }
    public string Categoria { get; set; }
}


