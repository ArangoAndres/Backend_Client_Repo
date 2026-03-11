public interface IClient
{
    Cliente GetClientById(int id);

    Cliente CreateClient(Cliente client);

    Cliente UpdateClient(int id, Cliente client);

    void DeleteClient(int id);
    
}