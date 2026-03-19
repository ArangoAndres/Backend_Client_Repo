using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/files")]
public class FileController : ControllerBase
{
    private readonly IFileInterface _fileService;

    public FileController(IFileInterface fileService)
    {
        _fileService = fileService;
    }


    private ArchivoResponseDTO MapToResponse(Archivo archivo)
{
    return new ArchivoResponseDTO
    {
        Id = archivo.Id,
        NombreOriginal = archivo.NombreOriginal,
        Ruta = archivo.Ruta,
        Tipo = archivo.tipo,
        FechaSubida = archivo.FechaSubida.ToDateTime(TimeOnly.MinValue),
        nombre_personalizado = archivo.nombre_personalizado,
        Peso = archivo.Peso
    };
}

    [Authorize]
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile([FromForm] ArchivoUploadDTO dto)
    {
        try
        {
            var archivo = await _fileService.UploadFile(dto);
return Ok(MapToResponse(archivo));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFileById(int id)
    {
        var archivo = await _fileService.GetFileById(id);
        if (archivo == null)
        {
            return NotFound("Archivo no encontrado");
        }
        return Ok(MapToResponse(archivo));
    }
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> ReplaceFile(int id, [FromForm] ArchivoUploadDTO
    dto)
        {
            try
            {
                var archivo = await _fileService.ReplaceFile(id, dto);
                return Ok(archivo);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFile(int id)
    {
        var deleted = await _fileService.DeleteFile(id);
        if (!deleted)
        {
            return NotFound("Archivo no encontrado");
        }
        return NoContent();
    }

    [Authorize]
    [HttpGet("cliente/{clientId}")]
    public async Task<IActionResult> GetAllFilesByClientId(int clientId)
    {
        var archivos = await _fileService.GetAllFilesByClientId(clientId);
        return Ok(archivos.Select(MapToResponse));
    }


    [Authorize]
    [HttpGet("download/{id}")]
    public async Task<IActionResult> DownloadFile(int id)
    {
        try
        {
            var (file, contentType, fileName) = await _fileService.DownloadFile(id);
            return File(file, contentType, fileName);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
}