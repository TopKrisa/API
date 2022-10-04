using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.NewsPapper.Commands.DeleteNewsPapper
{
    public class DeleteNewsPapperCommandHandler : IRequestHandler<DeleteNewsPapperCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public DeleteNewsPapperCommandHandler(IZabgcDbContext dbContext)=> _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteNewsPapperCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Newspappers.FirstOrDefaultAsync(np => np.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.Newspapper), request.Id);

            _dbContext.Newspappers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
