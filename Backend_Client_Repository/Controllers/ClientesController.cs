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
}