using MediatR;
using System;

namespace Zabgc.Application.Page.Commands.DeletePage
{
    public class DeletePageCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
