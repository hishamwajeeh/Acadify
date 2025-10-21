using Acadify.Core.Features.Student.Queries.Results;
using Acadify.Core.Wrappers;
using Acadify.Data.Enums;
using MediatR;

public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public StudentOrderingEnum OrderBy { get; set; }
    public string? Search { get; set; }

    public GetStudentPaginatedListQuery() { }

    public GetStudentPaginatedListQuery(int pageNumber, int pageSize, StudentOrderingEnum orderBy, string? search = null)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        OrderBy = orderBy;
        Search = search;
    }
}

