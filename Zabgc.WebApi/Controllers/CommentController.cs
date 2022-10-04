using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zabgc.Application.Comment.Commands.CreateComment;
using Zabgc.Application.Comment.Commands.DeleteComment;
using Zabgc.Application.Comment.Commands.UpdateComment;
using Zabgc.Application.Comment.Queries.GetCommentList;
using Zabgc.WebApi.Models.Comment;

namespace Zabgc.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentController : BaseController
    {
        private readonly IMapper _mapper;
        public CommentController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<CommentListVm>> Get()
        {
            var query = new GetCommentListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCommentDto createCommentDto)
        {
            var command = _mapper.Map<CreateCommentCommand>(createCommentDto);
            var commentId =  await Mediator.Send(command);

            return Ok(commentId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentDto updateCommentDto)
        {
            var command = _mapper.Map<UpdateCommentCommand>(updateCommentDto);
            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCommentCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
