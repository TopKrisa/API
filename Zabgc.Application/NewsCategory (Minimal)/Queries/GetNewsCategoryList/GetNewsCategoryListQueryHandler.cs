using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.NewsCategory.Queries.GetNewsCategoryList
{
    public class GetNewsCategoryListQueryHandler : IRequestHandler<GetNewsCategoryQuery, NewsCategoryListVm>
    {
        public readonly IZabgcDbContext _dbContext;
        public readonly IMapper _mapper;

        public GetNewsCategoryListQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NewsCategoryListVm> Handle(GetNewsCategoryQuery request, CancellationToken cancellationToken)
        {
            var newsCategoryQuery = await _dbContext.NewsCategories
                .ProjectTo<NewsCategoryLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new NewsCategoryListVm { NewsCategories = newsCategoryQuery };
        }
    }
}
