using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Entities
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public Guid DepartmentSenderId { get; set; }
        public Guid DepartmentReceiverId { get; set; }
        public Guid ClientSenderId { get; set; }
        public Guid ClientReceiverId { get; set; }
        public string TrackId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DepartureDate { get; set; }
        public virtual Department DepartmentSender { get; set; }
        public virtual Department DepartmentReceiver { get; set; }
        public virtual Client ClientSender { get; set; }
        public virtual Client ClientReceiver { get; set; }
        public virtual ICollection<TrackLog> TrackLogs { get; set; } 
        public virtual ICollection<Box> Boxes { get; set; }
    }
}
