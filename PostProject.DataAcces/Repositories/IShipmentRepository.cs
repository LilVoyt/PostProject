using PostProject.DataAcces.Entities;

namespace PostProject.DataAcces.Repositories
{
    public interface IShipmentRepository
    {
        Task<Guid> PostShipment(Shipment shipment);
    }
}