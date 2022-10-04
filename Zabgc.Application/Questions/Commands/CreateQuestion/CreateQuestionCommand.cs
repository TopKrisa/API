using MediatR;
using System;

namespace Zabgc.Application.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Name { get; set; } 
        public bool Activity { get; set; }
        public string AdminName { get; set; }

    }
}
