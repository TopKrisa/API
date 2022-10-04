using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Questions.Queries.GetQuestionList
{
    public class GetQuestionListQueryHandler : IRequestHandler<GetQuestionListQuery, QuestionListVm>
    {
        public readonly IZabgcDbContext _dbContext;
        public readonly IMapper _mapper;

        public GetQuestionListQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<QuestionListVm> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
        {
            var questionQuery = await _dbContext.Questions.
                  ProjectTo<QuestionLookupDto>(_mapper.ConfigurationProvider)
                  .ToListAsync(cancellationToken);

            return new QuestionListVm { Questions = questionQuery };
        }
    }
}
