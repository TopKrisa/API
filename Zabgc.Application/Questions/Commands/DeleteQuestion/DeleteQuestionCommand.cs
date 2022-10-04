using MediatR;
using System;

namespace Zabgc.Application.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
