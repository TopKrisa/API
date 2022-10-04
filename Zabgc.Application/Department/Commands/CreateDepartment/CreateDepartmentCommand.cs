using MediatR;
using System;

namespace Zabgc.Application.Department.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
