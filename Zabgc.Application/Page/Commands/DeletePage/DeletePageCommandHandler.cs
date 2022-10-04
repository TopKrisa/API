using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Page.Commands.DeletePage
{
    public class DeletePageCommandHandler : IRequestHandler<DeletePageCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public DeletePageCommandHandler(IZabgcDbContext dbContext)=> _dbContext = dbContext;

        public async Task<Unit> Handle(DeletePageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pages.FirstOrDefaultAsync(page => page.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.Page), request.Id);
                
             _dbContext.Pages.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
