using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Page.Commands.CreatePage
{
    public class CreatePageCommandHandler : IRequestHandler<CreatePageCommand, Guid>
    {
        private readonly IZabgcDbContext _dbContext;

        public CreatePageCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreatePageCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.Page()
            {
                Id = request.Id,
                CreationDate = DateTime.Now,
                Name = request.Name,
                Text = request.Text,
                PageCategoryId = request.PageCategoryId

            };

            await _dbContext.Pages.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
