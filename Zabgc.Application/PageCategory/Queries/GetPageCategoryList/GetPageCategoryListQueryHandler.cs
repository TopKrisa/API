using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.PageCategory.Queries.GetPageCategoryList
{
    public class GetPageCategoryListQueryHandler : IRequestHandler<GetPageCategoryListQuery, PageCategoryListVm>
    {
        public readonly IZabgcDbContext _dbContext;
        public readonly IMapper _mapper;

        public GetPageCategoryListQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PageCategoryListVm> Handle(GetPageCategoryListQuery request, CancellationToken cancellationToken)
        {
            var query = await _dbContext.PageCategories
                .ProjectTo<PageCategoryLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PageCategoryListVm { PageCategories = query };
        }
    }
}
