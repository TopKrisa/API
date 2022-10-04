using MediatR;
using System;

namespace Zabgc.Application.NewsCategory.Commands.CreateNewsCategory
{
    public class CreateNewsCategoryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
