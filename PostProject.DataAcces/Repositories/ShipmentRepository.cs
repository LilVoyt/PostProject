using Microsoft.EntityFrameworkCore;
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


        public async Task<List<Shipment>> GetShipmentsByClientId(Guid id)
        {
            List<Shipment> shipments = await dataContext.Shipments.Where(s => s.ClientSenderId == id || s.ClientReceiverId == id).ToListAsync();
            return shipments;
        }
    }
}
