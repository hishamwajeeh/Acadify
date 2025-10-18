using Acadify.Core.Bases;
using Acadify.Core.Features.Student.Commands.Models;
using Acadify.Service.Abstracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Core.Features.Student.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }


        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Acadify.Data.Entities.Student>(request);

            var result = await _studentService.AddStudentAsync(studentMapper);

            if (result == "Exist") return UnprocessableEntity<string>("Student Already Exist");
            else if (result == "Success") return Created("Added Successfully");
            else return BadRequest<string>("Something Went Wrong");
        }
    }
}
