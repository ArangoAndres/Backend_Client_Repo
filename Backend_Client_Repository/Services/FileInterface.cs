public interface IFileInterface
{
    Archivo GetFileById(int id);
    Archivo UploadFile(Archivo file);
    void deleteFile(int id);
    List<Archivo> GetAllFilesByClientId(int clientId);
}