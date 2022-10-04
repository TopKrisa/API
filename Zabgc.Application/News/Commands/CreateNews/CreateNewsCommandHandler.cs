using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.News.Commands.CreateNews
{
    public class CreateNewsCommandHandler
        : IRequestHandler<CreateNewsCommand, Guid>
    {
        private readonly IZabgcDbContext _dbContext;

        public CreateNewsCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = new Domain.Models.News
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Message = request.Message,
                PosterUrl = request.PosterUrl,
                CreationDate = DateTime.Now,
                NewsCategoryId = request.NewsCategoryId
                
            };

            await _dbContext.News.AddAsync(news,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return news.Id;
        }
    }
}
