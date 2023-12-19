using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Venta
{
    [Key]
    public int VentaId { get; set; }

    [Required]
    public DateTime FechaVenta { get; set; }

    [Required]
    [ForeignKey("Producto")]
    public int ProductoId { get; set; }

    public Producto Producto { get; set; }

    [Required]
    public int Cantidad { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public decimal PrecioTotal { get; set; }

    [Required]
    [ForeignKey("Usuario")]
    public int VendedorId { get; set; }

    public Usuario Vendedor { get; set; }
}
