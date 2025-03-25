﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.DTOs
{
    public record BoxDto(Guid Id, double Weight, double Height, double Width, decimal? Price);
}
