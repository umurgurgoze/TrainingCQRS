using MediatR;
using System.Collections.Generic;
using Training.CQRS.CQRS.Results;

namespace Training.CQRS.CQRS.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}
