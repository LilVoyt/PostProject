using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }
        public virtual ICollection<Shipment> SentShipments { get; set; }
        public virtual ICollection<Shipment> ReceivedShipments { get; set; }
    }
}
