using Microsoft.EntityFrameworkCore;

public class FileService : IFileInterface
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public FileService(AppDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task<Archivo?> GetFileById(int id)
    {
        return await _context.Archivos.FindAsync(id);
    }

    // 🔥 MÉTODO PRIVADO PARA NO DUPLICAR LÓGICA
    private async Task<(string ruta, string nombreOriginal, string tipo, int peso)> GuardarArchivo(IFormFile file)
    {
        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadsFolder);

        var cleanFileName = Path.GetFileName(file.FileName);
        var uniqueFileName = $"{Guid.NewGuid()}_{cleanFileName}";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return (
            ruta: $"/uploads/{uniqueFileName}",
            nombreOriginal: cleanFileName,
            tipo: file.ContentType,
            peso: (int)file.Length
        );
    }

    // ✅ Subir archivo
    public async Task<Archivo> UploadFile(ArchivoUploadDTO dto)
    {
        var file = dto.Archivo;

        if (file == null || file.Length == 0)
            throw new ArgumentException("Archivo no válido.");

        // Validación básica
        var allowedExtensions = new[] { ".pdf", ".jpg", ".png" };
        var extension = Path.GetExtension(file.FileName).ToLower();

        if (!allowedExtensions.Contains(extension))
            throw new ArgumentException("Tipo de archivo no permitido.");

        var data = await GuardarArchivo(file);

        var archivo = new Archivo
        {
            NombreOriginal = data.nombreOriginal,
            Ruta = data.ruta,
            tipo = data.tipo,
            FechaSubida = DateOnly.FromDateTime(DateTime.Now),
            nombre_personalizado = dto.nombre_personalizado,
            Peso = data.peso,
            ClienteId = dto.ClienteId
        };

        _context.Archivos.Add(archivo);
        await _context.SaveChangesAsync();

        return archivo;
    }

    // ✅ Reemplazar archivo
    public async Task<Archivo> ReplaceFile(int id, ArchivoUploadDTO dto)
    {
        var archivo = await GetFileById(id);

        if (archivo == null)
            throw new ArgumentException("Archivo no encontrado.");

        var file = dto.Archivo;

        if (file == null || file.Length == 0)
            throw new ArgumentException("Archivo no válido.");

        // Validación básica
        var allowedExtensions = new[] { ".pdf", ".jpg", ".png" };
        var extension = Path.GetExtension(file.FileName).ToLower();

        if (!allowedExtensions.Contains(extension))
            throw new ArgumentException("Tipo de archivo no permitido.");

        // 🔥 BORRAR ARCHIVO ANTERIOR
        var oldPath = Path.Combine(_environment.WebRootPath, archivo.Ruta.TrimStart('/'));

        if (File.Exists(oldPath))
        {
            File.Delete(oldPath);
        }

        var data = await GuardarArchivo(file);

        archivo.NombreOriginal = data.nombreOriginal;
        archivo.Ruta = data.ruta;
        archivo.tipo = data.tipo;
        archivo.FechaSubida = DateOnly.FromDateTime(DateTime.Now);
        archivo.nombre_personalizado = dto.nombre_personalizado;
        archivo.Peso = data.peso;

        _context.Archivos.Update(archivo);
        await _context.SaveChangesAsync();

        return archivo;
    }

    // ✅ Eliminar archivo (BD + físico)
    public async Task<bool> DeleteFile(int id)
    {
        var archivo = await GetFileById(id);

        if (archivo == null)
            return false;

        var filePath = Path.Combine(_environment.WebRootPath, archivo.Ruta.TrimStart('/'));

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        _context.Archivos.Remove(archivo);
        await _context.SaveChangesAsync();

        return true;
    }

    // ✅ Obtener archivos por cliente
    public async Task<List<Archivo>> GetAllFilesByClientId(int clientId)
    {
        return await _context.Archivos
            .Where(a => a.ClienteId == clientId)
            .ToListAsync();
    }

    // ✅ Descargar archivo
    public async Task<(byte[] file, string contentType, string fileName)> DownloadFile(int id)
    {
        var archivo = await GetFileById(id);

        if (archivo == null)
            throw new ArgumentException("Archivo no encontrado.");

        var filePath = Path.Combine(_environment.WebRootPath, archivo.Ruta.TrimStart('/'));

        if (!File.Exists(filePath))
            throw new FileNotFoundException("Archivo físico no encontrado.");

        var bytes = await File.ReadAllBytesAsync(filePath);

        return (bytes, archivo.tipo, archivo.NombreOriginal);
    }
}