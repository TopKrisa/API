using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Page.Queries.GetPageList
{
    public class GetPageListQueryHandler : IRequestHandler<GetPageListQuery, PageListVm>
    {
        private readonly IZabgcDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPageListQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PageListVm> Handle(GetPageListQuery request, CancellationToken cancellationToken)
        {
           var pageQuery = await _dbContext.Pages.
                ProjectTo<PageLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PageListVm{ Pages = pageQuery };
        }
    }
}
