using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Entities
{
    public class Box
    {
        public Guid Id { get; set; }
        public Guid ShipmentId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public decimal Price { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}
