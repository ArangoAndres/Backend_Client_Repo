public interface IFileInterface
{
    Task<Archivo?> GetFileById(int id);

    Task<Archivo> UploadFile(ArchivoUploadDTO dto);

Task<Archivo> ReplaceFile(int id, ArchivoUploadDTO dto);

    Task<bool> DeleteFile(int id);

    Task<List<Archivo>> GetAllFilesByClientId(int clientId);

    Task<(byte[] file, string contentType, string fileName)> DownloadFile(int id);
}