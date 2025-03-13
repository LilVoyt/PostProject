using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime DateHired { get; set; }
        public virtual Department Department { get; set; }
    }
}
