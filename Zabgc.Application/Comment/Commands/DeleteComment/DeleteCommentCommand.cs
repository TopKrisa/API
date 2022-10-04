using System;
using MediatR;
using System.Threading.Tasks;

namespace Zabgc.Application.Comment.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
