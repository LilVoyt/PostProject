using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.DTOs
{
    public record ClientDto(Guid Id, string FirstName, string LastName, DateTime BirthDay, 
        string PhoneNumber, string Email, DateTime DateJoined, string Password);
}
