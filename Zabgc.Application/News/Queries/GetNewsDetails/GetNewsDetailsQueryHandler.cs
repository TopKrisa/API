using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.News.Queries.GetNoteDetails
{
    public class GetNewsDetailsQueryHandler : IRequestHandler<GetNewsDetailsQuery, NewsDetailsVm>
    {
        private readonly IZabgcDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNewsDetailsQueryHandler(IZabgcDbContext dbContext, IMapper mapper )=> (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NewsDetailsVm> Handle(GetNewsDetailsQuery request, CancellationToken cancellationToken)
        {
           var entity = await _dbContext.News.FirstOrDefaultAsync(news =>
           news.Id == request.Id, cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Zabgc.Domain.Models.News), request.Id);

            return _mapper.Map<NewsDetailsVm>(entity);
        }
    }
}
