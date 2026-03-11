public interface IFileInterface
{
    Task<Archivo> GetFileById(int id);
    Task<Archivo> UploadFile(Archivo file);
    Task<bool> DeleteFile(int id);
    Task<List<Archivo>> GetAllFilesByClientId(int clientId);
}