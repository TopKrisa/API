using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Schedule.Commands.CreateShedule
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, Guid>
    {
        private readonly IZabgcDbContext _dbContext;

        public CreateScheduleCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.Schedule()
            {
                Id = request.Id,
                Date = DateTime.Now,
                Name = request.Name,
                ScheduleTypeId = request.ScheduleTypeId,
                Url = request.Url
            };

            await _dbContext.Schedules.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
