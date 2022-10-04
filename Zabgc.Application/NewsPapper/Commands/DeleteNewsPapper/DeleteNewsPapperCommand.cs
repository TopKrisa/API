using MediatR;
using System;

namespace Zabgc.Application.NewsPapper.Commands.DeleteNewsPapper
{
    public class DeleteNewsPapperCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
