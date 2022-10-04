using MediatR;
using System;

namespace Zabgc.Application.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
