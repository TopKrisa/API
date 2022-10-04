using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.NewsPapper.Commands.CreateNewsPapper
{
    public class CreateNewsPapperCommandHandler : IRequestHandler<CreateNewsPapperCommand, Guid>
    {
        private readonly IZabgcDbContext _dbContext;

        public CreateNewsPapperCommandHandler(IZabgcDbContext dbContext)=> _dbContext = dbContext;

        public async Task<Guid> Handle(CreateNewsPapperCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.Newspapper()
            {
                Id = request.Id,
                Date = request.Date,
                Name = request.Name,
                Url = request.Url
            };

            await _dbContext.Newspappers.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
