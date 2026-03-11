public class Cliente
{
    public int Id { get; set; }

    public required string Nombre { get; set; }

    public required string Email { get; set; }

    public int Cedula { get; set; }

    public required string Telefono { get; set; }

    public required string Direccion { get; set; }

    public required string Ciudad { get; set; }

    public required string Departamento { get; set; }

    public DateOnly FechaCreacion { get; set; }

    // Relaciones
    public List<Archivo> Archivos { get; set; } = new();

    public List<Observacion> Observaciones { get; set; } = new();
}