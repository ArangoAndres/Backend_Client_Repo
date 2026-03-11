public interface IobservacionesInterface
{
    Observacion GetObservacionById(int id);
    Observacion CreateObservacion(Observacion observacion);
    Observacion UpdateObservacion(int id, Observacion observacion);
    void DeleteObservacion(int id);
    List<Observacion> GetAllObservacionesByClientId(int clientId);
}