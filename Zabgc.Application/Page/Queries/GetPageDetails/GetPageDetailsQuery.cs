using MediatR;
using System;

namespace Zabgc.Application.Page.Queries.GetPageDetails
{
    public class GetPageDetailsQuery : IRequest<PageDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
