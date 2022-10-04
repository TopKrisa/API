using System;
using System.Collections.Generic;
using MediatR;

namespace Zabgc.Application.Comment.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string Message { get; set; }
        public Domain.Models.Comment Answer { get; set; }
    }
}
