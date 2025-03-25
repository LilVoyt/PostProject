using PostProject.DataAcces.Entities;

namespace PostProject.DataAcces.Repositories
{
    public interface ITrackLogRepository
    {
        Task<TrackLog> LogShipment(Guid shipmentId, string message);
    }
}