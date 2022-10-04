using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Department.Queries.GetDepartmentList
{
    public class GetDepartmentsListQueryHandler : IRequestHandler<GetDepartmentsListQuery, DepartmentsListVm>
    {
        private readonly IZabgcDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDepartmentsListQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DepartmentsListVm> Handle(GetDepartmentsListQuery request, CancellationToken cancellationToken)
        {
            var departmentsQuery = await _dbContext.Departments.
                ProjectTo<DepartmentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DepartmentsListVm() { Departments = departmentsQuery };
        }
    }
}
