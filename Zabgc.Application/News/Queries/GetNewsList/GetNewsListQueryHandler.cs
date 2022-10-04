using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.News.Queries.GetNewsList
{
    public class GetNewsListQueryHandler : IRequestHandler<GetNewsListQuery, NewsListVm>
    {
        public readonly IZabgcDbContext _dbContext;
        public readonly IMapper _mapper;

        public GetNewsListQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NewsListVm> Handle(GetNewsListQuery request, CancellationToken cancellationToken)
        {
            var newsQuery = await _dbContext.News.
                ProjectTo<NewsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new NewsListVm { News = newsQuery };
        }
    }
}
