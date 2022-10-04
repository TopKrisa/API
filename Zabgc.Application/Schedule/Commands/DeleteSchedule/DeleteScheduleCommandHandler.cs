using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Schedule.Commands.DeleteSchedule
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public DeleteScheduleCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Schedules.FirstOrDefaultAsync(s => s.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.Schedule), entity);

            _dbContext.Schedules.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
