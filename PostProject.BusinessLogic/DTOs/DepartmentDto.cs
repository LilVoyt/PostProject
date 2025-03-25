using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.DTOs
{
    public record DepartmentDto(Guid Id, string Address, string PhoneNumber, string Email);
}
