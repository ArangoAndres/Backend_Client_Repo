using Microsoft.EntityFrameworkCore;

public class ObservacionesService : IobservacionesInterface
{
    private readonly AppDbContext _context;

    public ObservacionesService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Observacion> CreateObservacion(CreateObservacionDTO dto)
    {
        var observacion = new Observacion
        {
            ObservacionTexto = dto.ObservacionTexto,
            ClienteId = dto.ClienteId,
            Fecha = DateOnly.FromDateTime(DateTime.Now)
        };

        _context.Observaciones.Add(observacion);

        await _context.SaveChangesAsync();

        return observacion;
    }

    public async Task<bool> DeleteObservacion(int id)
    {
        var observacion = await _context.Observaciones
            .FirstOrDefaultAsync(o => o.Id == id);

        if (observacion == null)
            return false;

        _context.Observaciones.Remove(observacion);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Observacion>> GetAllObservacionesByClientId(int clientId)
    {
        return await _context.Observaciones
            .Where(o => o.ClienteId == clientId)
            .OrderByDescending(o => o.Fecha)
            .ToListAsync();
    }

    public async Task<Observacion?> GetObservacionById(int id)
    {
        return await _context.Observaciones
            .FirstOrDefaultAsync(o => o.Id == id);
    }
}