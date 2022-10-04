using MediatR;
using System;

namespace Zabgc.Application.NewsPapper.Queries.GetNewsPapperList
{
    public class GetNewsPapperQuery : IRequest<NewsPapperListVm>
    {
        public Guid Id { get; set; }
    }
}
