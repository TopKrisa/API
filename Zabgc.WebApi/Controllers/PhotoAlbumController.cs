using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zabgc.Application.PhotoAlbum.Commands.CreatePhotoAlbum;
using Zabgc.Application.PhotoAlbum.Commands.DeletePhotoAlbum;
using Zabgc.Application.PhotoAlbum.Commands.UpdatePhotoAlbum;
using Zabgc.Application.PhotoAlbum.Queries.GetPhotoAlbumList;
using Zabgc.WebApi.Models.PhotoAlbum;

namespace Zabgc.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PhotoAlbumController : BaseController
    {
        private readonly IMapper _mapper;
        public PhotoAlbumController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PhotoAlbumListVm>> Get()
        {
            var query = new GetPhotoAlbumListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePhotoAlbumDto createPhotoAlbumDto)
        {
            var command = _mapper.Map<CreatePhotoAlbumCommand>(createPhotoAlbumDto);
            var photoAlbumId = await Mediator.Send(command);

            return Ok(photoAlbumId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePhotoAlbumDto updatePhotoAlbumDto)
        {
            var command = _mapper.Map<UpdatePhotoAlbumCommand>(updatePhotoAlbumDto);
            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePhotoAlbumCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
