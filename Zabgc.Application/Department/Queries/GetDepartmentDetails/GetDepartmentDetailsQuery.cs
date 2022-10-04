using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabgc.Application.Department.Queries.GetDepartmentDetails
{
    public class GetDepartmentDetailsQuery : IRequest<DepartmentDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
