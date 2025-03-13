using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Entities
{
    public class TrackLog
    {
        public Guid Id { get; set; }
        public string TrackId { get; set; }
        public string Message { get; set; }
        public DateTime ProceedTime { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}
