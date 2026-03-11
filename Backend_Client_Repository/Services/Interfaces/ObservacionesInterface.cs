public interface IobservacionesInterface
{
    Task<Observacion> GetObservacionById(int id);
    Task<Observacion> CreateObservacion(Observacion observacion);
    Task<Observacion> UpdateObservacion(int id, Observacion observacion);
    Task<bool> DeleteObservacion(int id);
    Task<List<Observacion>> GetAllObservacionesByClientId(int clientId);
}