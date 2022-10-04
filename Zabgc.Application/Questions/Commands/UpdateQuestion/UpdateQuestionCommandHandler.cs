using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public UpdateQuestionCommandHandler(IZabgcDbContext dbContext)=> _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Questions.FirstOrDefaultAsync(quest => quest.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.Question), request.Id);

            entity.Id = request.Id;
            entity.Answer = request.Answer;
            entity.Message = request.Message;
            entity.AdminName = request.AdminName;
            entity.Activity = true;
            entity.ResponseDate = DateTime.Now;
            entity.User = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
