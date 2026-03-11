public interface LoginInterface
{
    Task<Usuario?> Login(string username, string password);
    
}