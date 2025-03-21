using PostProject.DataAcces.Data;
using PostProject.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Repositories
{
    public class ShipmentRepository(DataContext dataContext) : IShipmentRepository
    {
        public async Task<Guid> PostShipment(Shipment shipment)
        {
            await dataContext.AddAsync(shipment);
            await dataContext.SaveChangesAsync();
            return shipment.Id;
        }
    }
}
