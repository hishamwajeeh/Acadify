﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Core.Features.Student.Queries.Results
{
    public class GetStudentListResponse
    {
        public int StudId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? DepartmrntName { get; set; }
    }
}
