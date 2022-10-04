using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.PhotoAlbum.Commands.UpdatePhotoAlbum
{
    public class UpdatePhotoAlbumCommandHandler : IRequestHandler<UpdatePhotoAlbumCommand, Unit>
    {
        private readonly IZabgcDbContext _dbContext;

        public UpdatePhotoAlbumCommandHandler(IZabgcDbContext dbContext)=> _dbContext=dbContext;

        public async Task<Unit> Handle(UpdatePhotoAlbumCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.PhotoAlbums.FirstOrDefaultAsync(p=> p.Id == request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Models.PhotoAlbum), entity);

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.Department = request.Department;
            entity.Photos = request.Photos;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;    
        }
    }
}
