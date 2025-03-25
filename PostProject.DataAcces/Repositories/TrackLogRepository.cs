using Microsoft.EntityFrameworkCore;
using PostProject.DataAcces.Data;
using PostProject.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Repositories
{
    public class TrackLogRepository(DataContext dataContext) : ITrackLogRepository
    {
        public async Task<TrackLog> LogShipment(Guid shipmentId, string message)
        {
            Shipment shipment = await dataContext.Shipments.FirstOrDefaultAsync(s => s.Id == shipmentId)
                ?? throw new DataException("Shipment with this id was not found!");

            TrackLog trackLog = new TrackLog()
            {
                Id = Guid.NewGuid(),
                TrackId = shipment.TrackId,
                Message = message,
                ProceedTime = DateTime.Now,
            };
            await dataContext.TrackLogs.AddAsync(trackLog);
            await dataContext.SaveChangesAsync();

            return trackLog;
        }
    }
}
