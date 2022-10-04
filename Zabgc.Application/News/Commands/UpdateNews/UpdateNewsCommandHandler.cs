using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.News.Commands.UpdateNews
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public UpdateNewsCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {

            var entity = await _dbContext.News.FirstOrDefaultAsync(x =>x.Id == request.Id);
            if(entity == null)
                throw new NotFoundException(nameof(Domain.Models.News), request.Id);

            entity.Name = request.Name;
            entity.EditionDate = System.DateTime.Now;
            entity.Description = request.Description;
            entity.Message = request.Message;
            entity.PosterUrl = request.PosterUrl;
            entity.NewsCategoryId = request.NewsCategoryId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
