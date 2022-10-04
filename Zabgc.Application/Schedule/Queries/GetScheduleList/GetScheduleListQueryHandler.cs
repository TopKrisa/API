using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Schedule.Queries.GetScheduleList
{
    public class GetScheduleListQueryHandler : IRequestHandler<GetScheduleListQuery, ScheduleListVm>
    {
        private readonly IZabgcDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetScheduleListQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ScheduleListVm> Handle(GetScheduleListQuery request, CancellationToken cancellationToken)
        {
            var scheduleQuery = await _dbContext.Schedules
                .ProjectTo<ScheduleLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ScheduleListVm() { Schedules = scheduleQuery };
        }
    }
}
