using MediatR;
using System;

namespace Zabgc.Application.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public bool Activity { get; set; }
        public string Answer { get; set; }
        public string AdminName { get; set; }
    }
}
