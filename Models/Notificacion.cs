using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Notificacion
{
    [Key]
    public int NotificacionId { get; set; }

    [Required]
    [ForeignKey("Producto")]
    public int ProductoId { get; set; }

    public Producto Producto { get; set; }

    [Required]
    public string Mensaje { get; set; }

    [Required]
    public DateTime FechaNotificacion { get; set; }

    [Required]
    public bool Atendida { get; set; } // Indica si la notificación fue atendida
}
