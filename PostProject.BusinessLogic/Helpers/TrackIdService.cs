using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.Helpers
{
    public class TrackIdService : ITrackIdService
    {
        public string GenerateNumericTrackId(int length = 12)
        {
            var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            var randomPart = new Random().Next(1000, 9999).ToString();
            return $"{timestamp}{randomPart}";
        }
    }
}
