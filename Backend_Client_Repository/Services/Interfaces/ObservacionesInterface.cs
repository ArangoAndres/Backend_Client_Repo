public interface IobservacionesInterface
{
    Task<Observacion> GetObservacionById(int id);
    Task<Observacion> CreateObservacion(CreateObservacionDTO dto);
    Task<bool> DeleteObservacion(int id);
    Task<List<Observacion>> GetAllObservacionesByClientId(int clientId);
}