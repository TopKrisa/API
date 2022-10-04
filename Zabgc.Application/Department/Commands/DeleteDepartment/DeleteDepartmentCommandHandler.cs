using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public DeleteDepartmentCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Departments.FirstOrDefaultAsync(dept => 
            dept.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.News), request.Id);

            _dbContext.Departments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
