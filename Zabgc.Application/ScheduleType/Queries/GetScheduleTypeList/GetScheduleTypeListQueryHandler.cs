using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.ScheduleType.Queries.GetScheduleTypeList
{
    public class GetScheduleTypeListQueryHandler : IRequestHandler<GetScheduleTypeListQuery, ScheduleTypeListVm>
    {
        private readonly IZabgcDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetScheduleTypeListQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ScheduleTypeListVm> Handle(GetScheduleTypeListQuery request, CancellationToken cancellationToken)
        {
            var query = await _dbContext.ScheduleTypes
                .ProjectTo<ScheduleTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ScheduleTypeListVm { ScheduleTypes = query };
        }
    }
}
