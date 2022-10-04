using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Comment.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public DeleteCommentCommandHandler(IZabgcDbContext dbContext)=> _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.Comment), request.Id);

            _dbContext.Comments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
