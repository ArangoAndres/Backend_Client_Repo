using System.ComponentModel.DataAnnotations.Schema;
public class Observacion
{
    public int Id { get; set; }

    [Column("observacion")]
    public required string ObservacionTexto { get; set; }

    public DateOnly Fecha { get; set; }

    // Foreign Key
    [Column("clientes_id")]
    public int ClienteId { get; set; }

    // Navegación
    public Cliente Cliente { get; set; }
}