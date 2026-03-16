using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/observaciones")]
public class ObservacionesController : ControllerBase
{
    private readonly IobservacionesInterface _observacionesService;

    public ObservacionesController(IobservacionesInterface observacionesService)
    {
        _observacionesService = observacionesService;
    }
[Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateObservacion(CreateObservacionDTO dto)
    {
        var observacion = await _observacionesService.CreateObservacion(dto);
        return Ok(observacion);
    }
    
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteObservacion(int id)
    {
        var deleted = await _observacionesService.DeleteObservacion(id);
        if (!deleted)
        {
            return NotFound("Observación no encontrada");
        }
        return Ok("Observación eliminada");
    }
    

    [Authorize]
    [HttpGet("cliente/{clientId}")]
   public async Task<IActionResult> GetAllObservacionesByClientId(int clientId)
    {
        var observaciones = await _observacionesService.GetAllObservacionesByClientId(clientId);
        return Ok(observaciones);
    }


    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetObservacionById(int id)
    {
        var observacion = await _observacionesService.GetObservacionById(id);
        if (observacion == null)
        {
            return NotFound("Observación no encontrada");
        }
        return Ok(observacion);
    }
}