public class Archivo
{
    public int Id { get; set; }

    public required string NombreOriginal { get; set; }

    public required string Ruta { get; set; }

    public String tipo { get; set; }

    public DateOnly FechaSubida { get; set; }

    public String? nombre_personalizado { get; set; }

    
    public int Peso { get; set; }

    // Foreign Key
    public int ClienteId { get; set; }

    // Navegación
    public virtual Cliente Cliente { get; set; }
}