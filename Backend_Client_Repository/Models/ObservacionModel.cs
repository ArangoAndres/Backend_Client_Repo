public class Observacion
{
    public int Id { get; set; }

    public required string ObservacionTexto { get; set; }

    public DateOnly Fecha { get; set; }

    // Foreign Key
    public int ClienteId { get; set; }

    // Navegación
    public Cliente Cliente { get; set; }
}