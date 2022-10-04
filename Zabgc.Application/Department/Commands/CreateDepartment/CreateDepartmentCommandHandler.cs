using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Department.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler 
        : IRequestHandler<CreateDepartmentCommand, Guid>
    {
        private readonly IZabgcDbContext _dbContext;

        public CreateDepartmentCommandHandler(IZabgcDbContext zabgcDbContext) => _dbContext = zabgcDbContext;


        public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Domain.Models.Department()
            {
                Name = request.Name,
                Text = request.Text
            };
            await _dbContext.Departments.AddAsync(department, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return department.Id;
        }
    }
}
