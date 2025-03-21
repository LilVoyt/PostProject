using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.DTOs
{
    public record AddShipmentDto(Guid DepartmentSenderId, Guid DepartmentReceiverId, Guid ClientSenderId, 
        Guid ClientReceiverId, string Description, decimal? Price, DateTime DepartureDate, List<BoxDto> BoxDtos);
}
