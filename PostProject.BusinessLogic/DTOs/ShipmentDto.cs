using PostProject.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.DTOs
{
    public record ShipmentDto(Guid Id, string TrackId, string Description, decimal Price, DateTime DepartureDate, 
        DepartmentDto DepartmentSender, DepartmentDto DepartmentReceiver, ClientDto ClientSender, ClientDto ClientReceiver, 
        ICollection<TrackLogDto> TrackLogs, ICollection<BoxDto> Boxes);
}
