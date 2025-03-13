using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; } 
        public string Email { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Shipment> IncomingShipment { get; set; }
        public virtual ICollection<Shipment> DepartingShipment { get; set; }
    }
}
