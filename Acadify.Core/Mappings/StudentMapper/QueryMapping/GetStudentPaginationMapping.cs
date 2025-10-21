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
        public void GetStudentPaginationMapping()
        {
            CreateMap<Student, GetStudentPaginatedListResponse>()
                .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.StudID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));

        }
    }
}
