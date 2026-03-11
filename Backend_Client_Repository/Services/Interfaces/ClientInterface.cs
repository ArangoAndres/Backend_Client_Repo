public interface IClientInterface
{
    Task<List<Cliente>> GetAllClients();
    Task<Cliente> GetClientById(int id);

    Task<Cliente> CreateClient(CreateClienteDTO client);

    Task<Cliente> UpdateClient(int id, Cliente client);

    Task<bool> DeleteClient(int id);

}