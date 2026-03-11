using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]

[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    private readonly IClientInterface _clientService;

    public ClientesController(IClientInterface clientService)
    {
        _clientService = clientService;
    }
[Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateCliente(CreateClienteDTO clienteDTO)
    {
        var cliente = await _clientService.CreateClient(clienteDTO);

        return Ok(cliente);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllClientes()
    {
        var clientes = await _clientService.GetAllClients();
        return Ok(clientes);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClienteById(int id)
    {
        try
        {
            var cliente = await _clientService.GetClientById(id);
            return Ok(cliente);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        try
        {
            var deleted = await _clientService.DeleteClient(id);
            if (!deleted)
            {
                return NotFound("Cliente no encontrado");
            }
            return Ok("Cliente eliminado");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

[Authorize]
[HttpPut("{id}")]
public async Task<IActionResult> UpdateCliente(int id, Cliente cliente)
{
    var updated = await _clientService.UpdateClient(id, cliente);

    return Ok(updated);
}
}