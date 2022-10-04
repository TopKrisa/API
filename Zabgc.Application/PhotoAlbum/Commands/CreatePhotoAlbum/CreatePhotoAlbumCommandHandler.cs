using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.PhotoAlbum.Commands.CreatePhotoAlbum
{
    public class CreatePhotoAlbumCommandHandler : IRequestHandler<CreatePhotoAlbumCommand, Guid>
    {
        private readonly IZabgcDbContext _dbContext;

        public CreatePhotoAlbumCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreatePhotoAlbumCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.PhotoAlbum()
            {
                Id = request.Id,
                Name = request.Name,
                Department = request.Department,
                Photos = request.Photos
            };

            await _dbContext.PhotoAlbums.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
