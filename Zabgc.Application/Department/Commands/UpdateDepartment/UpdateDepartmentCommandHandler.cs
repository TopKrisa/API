using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public UpdateDepartmentCommandHandler(IZabgcDbContext dbContext)=> _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == request.Id,
                cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.Department), request.Id);

            entity.Name = request.Name;
            entity.Text = request.Text;
            entity.EditionDate = System.DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
