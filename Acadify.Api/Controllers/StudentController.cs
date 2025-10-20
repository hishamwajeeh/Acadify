using Acadify.Api.Base;
using Acadify.Core.Features.Student.Commands.Models;
using Acadify.Core.Features.Student.Queries.Models;
using Acadify.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acadify.Api.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {
        
        [HttpGet(Router.StudentRouting.getAllStudents)]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.getStudentById)]
        public async Task<IActionResult> GetStudentByIdAsync([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetStudentByIdQuery(id)));
        }

        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] AddStudentCommand addStudentCommand)
        {
            var response = await Mediator.Send(addStudentCommand);
            return NewResult(response);
        }
    }
}
