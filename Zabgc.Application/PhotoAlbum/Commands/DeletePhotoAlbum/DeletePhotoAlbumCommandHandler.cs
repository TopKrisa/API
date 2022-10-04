using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.PhotoAlbum.Commands.DeletePhotoAlbum
{
    public class DeletePhotoAlbumCommandHandler : IRequestHandler<DeletePhotoAlbumCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public DeletePhotoAlbumCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeletePhotoAlbumCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.PhotoAlbums.FirstOrDefaultAsync(album => album.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.PhotoAlbum), request.Id);

            _dbContext.PhotoAlbums.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
