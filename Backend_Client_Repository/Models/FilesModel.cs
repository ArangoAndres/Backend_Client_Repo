public class Archivo
{
    public int Id { get; set; }

    public required string NombreOriginal { get; set; }

    public required string Ruta { get; set; }

    public DateOnly FechaSubida { get; set; }

    public long Peso { get; set; }

    // Foreign Key
    public int ClienteId { get; set; }

    // Navegación
    public Cliente Cliente { get; set; }
}