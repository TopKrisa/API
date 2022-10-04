using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.PhotoAlbum.Queries.GetPhotoAlbumList
{
    public class GetPhotoAlbumListQueryHandler : IRequestHandler<GetPhotoAlbumListQuery, PhotoAlbumListVm>
    {
        private readonly IZabgcDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPhotoAlbumListQueryHandler(IZabgcDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PhotoAlbumListVm> Handle(GetPhotoAlbumListQuery request, CancellationToken cancellationToken)
        {
            var photoAlbumQuery = await _dbContext.PhotoAlbums
                .ProjectTo<PhotoAlbumLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PhotoAlbumListVm() { PhotoAlbums = photoAlbumQuery };
        }
    }
}
