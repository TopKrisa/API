using MediatR;
using System;

namespace Zabgc.Application.News.DeleteNews
{
    public class DeleteNewsCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
