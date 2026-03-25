using System.ComponentModel.DataAnnotations.Schema;

[Table("files")]
public class Archivo
{
    public int Id { get; set; }
    [Column("nombre_original")]
    public required string NombreOriginal { get; set; }

    [Column("ruta")]
    public required string Ruta { get; set; }

    public String tipo { get; set; }

    [Column("fecha_subida")]
    public DateOnly FechaSubida { get; set; }

    public String? nombre_personalizado { get; set; }

    
    public int Peso { get; set; }

    // Foreign Key
     [Column("clientes_id")]
    public int ClienteId { get; set; }

    // Navegación
    public virtual Cliente Cliente { get; set; }
}