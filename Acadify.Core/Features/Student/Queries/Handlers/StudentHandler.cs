using Acadify.Core.Features.Student.Queries.Models;
using Acadify.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Core.Features.Student.Queries.Handlers
{
    public class StudentHandler : IRequestHandler<GetStudentListQuery, List<Data.Entities.Student>>
    {
        private readonly IStudentService _studentService;

        public StudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<List<Data.Entities.Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetAllStudentsAsync();
        }
    }
}
