using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.DTOs
{
    public record TrackLogDto(Guid Id, string TrackId, string Message, DateTime ProceedTime);
}
