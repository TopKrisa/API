using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Schedule.Commands.UpdateSchedule
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public UpdateScheduleCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Schedules.FirstOrDefaultAsync(s => s.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.Schedule), request.Id);

            entity.Url = request.Url;
            entity.ScheduleTypeId = request.ScheduleTypeId;
            entity.Name = request.Name;
            entity.Date = DateTime.Now;
            entity.Id = request.Id;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
