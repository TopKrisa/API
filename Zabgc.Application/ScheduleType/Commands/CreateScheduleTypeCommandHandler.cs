using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.ScheduleType.Commands
{
    public class CreateScheduleTypeCommandHandler : IRequestHandler<CreateScheduleTypeCommand, Guid>
    {
        private readonly IZabgcDbContext _dbContext;

        public CreateScheduleTypeCommandHandler(IZabgcDbContext dbContext)=> _dbContext = dbContext;

        public async Task<Guid> Handle(CreateScheduleTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.ScheduleType
            {
                Id = request.Id,
                Name = request.Name
            };
            await _dbContext.ScheduleTypes.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
