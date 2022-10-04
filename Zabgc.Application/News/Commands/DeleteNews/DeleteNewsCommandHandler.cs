using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;
using Zabgc.Domain.Models;

namespace Zabgc.Application.News.DeleteNews
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public DeleteNewsCommandHandler(IZabgcDbContext dbContext)=> _dbContext=dbContext;

        public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.News.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.News), request.Id);

            _dbContext.News.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
