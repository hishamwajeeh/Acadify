using Acadify.Core.Features.Student.Commands.Models;
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
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.Id));
        }
    }
}
