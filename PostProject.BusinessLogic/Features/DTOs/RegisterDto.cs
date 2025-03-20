using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.Features.DTOs
{
    public record RegisterDto(string FirstName, string LastName, DateTime BirthDay, 
        string PhoneNumber, string Email, DateTime DateJoined, string Password);
}
