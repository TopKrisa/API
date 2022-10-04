using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zabgc.Application.Interfaces;


namespace Zabgc.Application.Comment.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
    {
        private readonly IZabgcDbContext _dbContext;
        public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.Comment()
            {
                Id = request.Id,
                UserId = request.UserId,
                Answer = request.Answer,
                CreationDate = DateTime.Now,
                Message = request.Message,
            };
            await _dbContext.Comments.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
