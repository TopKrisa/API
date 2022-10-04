using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.Page.Commands.UpdatePage
{
    public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public UpdatePageCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdatePageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pages.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.Page), request.Id);

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.Text = request.Text;
            entity.EditionDate = DateTime.Now;
            entity.PageCategoryId = request.PageCategoryId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
