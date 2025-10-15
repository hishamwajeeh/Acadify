using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Core.Features.Student.Queries.Models
{
    public class GetStudentListQuery : IRequest<List<Acadify.Data.Entities.Student>>
    {
    }
}
