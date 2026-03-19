public class ArchivoUploadDTO
{
    public IFormFile Archivo { get; set; }

    public int ClienteId { get; set; }

    public string? nombre_personalizado { get; set; }
}

public class ArchivoResponseDTO
{
    public int Id { get; set; }

    public string NombreOriginal { get; set; }

    public string Ruta { get; set; }

    public string Tipo { get; set; }

    public DateTime FechaSubida { get; set; }

    public string? nombre_personalizado { get; set; }

    public long Peso { get; set; }
}