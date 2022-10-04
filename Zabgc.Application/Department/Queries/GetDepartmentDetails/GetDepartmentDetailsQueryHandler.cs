using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Department.Queries.GetDepartmentDetails
{
    public class GetDepartmentDetailsQueryHandler : IRequestHandler<GetDepartmentDetailsQuery, DepartmentDetailsVm>
    {
        private readonly IZabgcDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDepartmentDetailsQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DepartmentDetailsVm> Handle(GetDepartmentDetailsQuery request, CancellationToken cancellationToken)
        {
           var entity = await _dbContext.Departments.FirstOrDefaultAsync(dept=> 
           dept.Id == request.Id, cancellationToken);
            if(entity == null)
                throw new NotFoundException(nameof(Domain.Models.Department), request.Id);

            return _mapper.Map<DepartmentDetailsVm>(entity);
        }
    }
}
