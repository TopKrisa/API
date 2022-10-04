using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Guid>
    {
        private readonly IZabgcDbContext _dbContext;

        public CreateQuestionCommandHandler(IZabgcDbContext dbContext)=> _dbContext = dbContext;

        public async Task<Guid> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.Question()
            {
                Id = request.Id,
                User = request.Name,
                Message = request.Message,
                Activity = false,
                CreationDate = DateTime.Now,
            };

            await _dbContext.Questions.AddAsync(entity,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
