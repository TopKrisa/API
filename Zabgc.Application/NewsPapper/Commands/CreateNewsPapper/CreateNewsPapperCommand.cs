using MediatR;
using System;

namespace Zabgc.Application.NewsPapper.Commands.CreateNewsPapper
{
    public class CreateNewsPapperCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }
}
