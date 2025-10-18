using Acadify.Core.Features.Student.Commands.Models;
using Acadify.Core.Features.Student.Queries.Results;
using Acadify.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Core.Mappings
{
    public partial class StudentProfile
    {
       public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand, Student>()
            .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
