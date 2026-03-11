public interface IAuthService
{
    Task<string?> Login(string Username, string Password);
    Task Login(object username, object password);
}