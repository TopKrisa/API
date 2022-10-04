using MediatR;
using System;

namespace Zabgc.Application.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime EditionDate { get; set; }
    }
}
