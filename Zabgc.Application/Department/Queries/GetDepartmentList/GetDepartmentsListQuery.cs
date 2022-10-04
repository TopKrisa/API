using MediatR;
using System;

namespace Zabgc.Application.Department.Queries.GetDepartmentList
{
    public class GetDepartmentsListQuery : IRequest<DepartmentsListVm>
    {
    }
}
