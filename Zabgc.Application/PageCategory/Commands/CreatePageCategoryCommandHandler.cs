using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.PageCategory.Commands
{
    public class CreatePageCategoryCommandHandler : IRequestHandler<CreatePageCategoryCommand, Guid>
    {
        private readonly IZabgcDbContext _dbContext;

        public CreatePageCategoryCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(CreatePageCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.PageCategory
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description
            };

            await _dbContext.PageCategories.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
