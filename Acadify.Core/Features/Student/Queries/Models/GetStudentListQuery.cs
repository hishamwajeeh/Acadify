using Acadify.Core.Bases;
using Acadify.Core.Features.Student.Queries.Results;
using Azure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Core.Features.Student.Queries.Models
{
    public class GetStudentListQuery : IRequest<Bases.Response<List<GetStudentListResponse>>>
    {
    }
}
