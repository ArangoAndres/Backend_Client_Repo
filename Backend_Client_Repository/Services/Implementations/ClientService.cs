public class ClientService : IClientInterface
{

        private readonly AppDbContext _context;
    
        public ClientService(AppDbContext context)
        {
            _context = context;
        }
  public async Task<Cliente> CreateClient(CreateClienteDTO clientDTO)
{
    var cliente = new Cliente
    {
        Nombre = clientDTO.Nombre,
        Email = clientDTO.Email,
        Cedula = clientDTO.Cedula,
        Telefono = clientDTO.Telefono,
        Direccion = clientDTO.Direccion,
        Ciudad = clientDTO.Ciudad,
        Departamento = clientDTO.Departamento,
        fecha_creacion = DateOnly.FromDateTime(DateTime.Now)
    };

    _context.Clientes.Add(cliente);

    await _context.SaveChangesAsync();

    return cliente;
}



    public Task<bool> DeleteClient(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Cliente>> GetAllClients()
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> GetClientById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> UpdateClient(int id, Cliente client)
    {
        throw new NotImplementedException();
    }
}
