using MediatR;
using System;

namespace Zabgc.Application.PageCategory.Commands
{
    public class CreatePageCategoryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
    }
}
