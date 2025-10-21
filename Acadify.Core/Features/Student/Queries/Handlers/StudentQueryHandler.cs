using Acadify.Core.Bases;
using Acadify.Core.Features.Student.Queries.Models;
using Acadify.Core.Features.Student.Queries.Results;
using Acadify.Core.Wrappers;
using Acadify.Data.Enums;
using Acadify.Service.Abstracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Core.Features.Student.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>,
        IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentsList = await _studentService.GetAllStudentsAsync();
            var studentsListmapped = _mapper.Map<List<GetStudentListResponse>>(studentsList);
            return Success(studentsListmapped);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<GetSingleStudentResponse>("Student Not Found");
            var studentMapped = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(studentMapped);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(
        GetStudentPaginatedListQuery request,
        CancellationToken cancellationToken)
        {
            var query = _studentService.FilterStudentPaginationQueryable(request.OrderBy, request.Search);

            var mappedQuery = query.Select(student => new GetStudentPaginatedListResponse
            {
                StudID = student.StudID,
                Name = student.Name,
                Address = student.Address,
                DepartmentName = student.Department.DName
            });

            var paginatedList = await mappedQuery.ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;
        }
    }
}
