using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.Features.DTOs
{
    public record LoginDto(string PhoneNumber, string Password);
}
