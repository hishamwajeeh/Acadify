using Acadify.Core.Features.Student.Queries.Models;
using Acadify.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acadify.Api.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.StudenRouting.getAllStudents)]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }

        [HttpGet(Router.StudenRouting.getStudentById)]
        public async Task<IActionResult> GetStudentByIdAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);
        }
    }
}
