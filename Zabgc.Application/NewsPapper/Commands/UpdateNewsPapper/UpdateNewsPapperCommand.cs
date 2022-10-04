using MediatR;
using System;

namespace Zabgc.Application.NewsPapper.Commands.UpdateNewsPapper
{
    public class UpdateNewsPapperCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }
}
