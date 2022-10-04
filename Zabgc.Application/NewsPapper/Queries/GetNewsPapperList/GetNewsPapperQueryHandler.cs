using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.NewsPapper.Queries.GetNewsPapperList
{
    public class GetNewsPapperQueryHandler : IRequestHandler<GetNewsPapperQuery, NewsPapperListVm>
    {
        public readonly IZabgcDbContext _dbContext;
        public readonly IMapper _mapper;

        public GetNewsPapperQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NewsPapperListVm> Handle(GetNewsPapperQuery request, CancellationToken cancellationToken)
        {
            var newsPapperQuery = await _dbContext.Newspappers
                 .ProjectTo<NewsPapperLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync();

            return new NewsPapperListVm() { NewsPappers = newsPapperQuery };
        }
    }
}
