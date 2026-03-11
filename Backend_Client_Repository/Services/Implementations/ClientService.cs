using Microsoft.EntityFrameworkCore;
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



    public async Task<List<Cliente>> GetAllClients()
    {
       return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente> GetClientById(int id)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id) ??
         throw new Exception("Cliente no encontrado") ;
    }


    public Task<bool> DeleteClient(int id)
    {
        var cliente= _context.Clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null)
        {
            return Task.FromResult(false);
        }
        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        return Task.FromResult(true);

    }
    
    public async Task<Cliente> UpdateClient(int id, Cliente client)
    {
        var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        if (cliente == null)
        {
            throw new Exception("Cliente no encontrado");
        }
        // Update the cliente properties with the new values from 'client'
        cliente.Nombre = client.Nombre;
        cliente.Email = client.Email;
        cliente.Cedula = client.Cedula;
        cliente.Telefono = client.Telefono;
        cliente.Direccion = client.Direccion;
        cliente.Ciudad = client.Ciudad;
        cliente.Departamento = client.Departamento;
        await _context.SaveChangesAsync();
        return cliente;

    }
}
