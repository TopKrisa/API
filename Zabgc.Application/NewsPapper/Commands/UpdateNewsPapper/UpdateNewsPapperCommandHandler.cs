using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.NewsPapper.Commands.UpdateNewsPapper
{
    public class UpdateNewsPapperCommandHandler : IRequestHandler<UpdateNewsPapperCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public UpdateNewsPapperCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateNewsPapperCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Newspappers.FirstOrDefaultAsync(np => np.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.Newspapper), request.Id);

            entity.Name = request.Name;
            entity.Url = request.Url;
            entity.Date = request.Date;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
