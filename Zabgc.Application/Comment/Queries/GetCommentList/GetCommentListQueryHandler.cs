using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Comment.Queries.GetCommentList
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, CommentListVm>
    {
        public readonly IZabgcDbContext _dbContext;
        public readonly IMapper _mapper;

        public GetCommentListQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CommentListVm> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var commentQuery = await _dbContext.Comments.
                ProjectTo<CommentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new CommentListVm() { Comments = commentQuery };
        }
    }
}
