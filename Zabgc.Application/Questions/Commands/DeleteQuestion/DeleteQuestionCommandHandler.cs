using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public DeleteQuestionCommandHandler(IZabgcDbContext dbContext)=> _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Questions.FirstOrDefaultAsync(quest => quest.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.Question), request.Id);

            _dbContext.Questions.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
