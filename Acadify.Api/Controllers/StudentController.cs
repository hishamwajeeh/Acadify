using Acadify.Api.Base;
using Acadify.Core.Features.Student.Commands.Models;
using Acadify.Core.Features.Student.Queries.Models;
using Acadify.Core.Features.Student.Queries.Results;
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

        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] AddStudentCommand addStudentCommand)
        {
            var response = await Mediator.Send(addStudentCommand);
            return NewResult(response);
        }

        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> EditAsync([FromBody] EditStudentCommand editStudentCommand)
        {
            var response = await Mediator.Send(editStudentCommand);
            return NewResult(response);
        }

        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteStudentCommand(id)));
        }
    }
}
