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
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>()
            .ForMember(dest => dest.DepartmrntName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}
