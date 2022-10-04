using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zabgc.Application.NewsPapper.Commands.CreateNewsPapper;
using Zabgc.Application.NewsPapper.Commands.DeleteNewsPapper;
using Zabgc.Application.NewsPapper.Commands.UpdateNewsPapper;
using Zabgc.Application.NewsPapper.Queries.GetNewsPapperList;
using Zabgc.WebApi.Models.NewsPapper;

namespace Zabgc.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NewsPapperController : BaseController
    {
        private readonly IMapper _mapper;
        public NewsPapperController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<NewsPapperListVm>> Get()
        {
            var query = new GetNewsPapperQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNewsPapperDto createNewsPapperDto)
        {
            var command = _mapper.Map<CreateNewsPapperCommand>(createNewsPapperDto);
            var npId = await Mediator.Send(command);

            return npId;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNewsPapperDto updateNewsPapperDto)
        {
            var command = _mapper.Map<UpdateNewsPapperCommand>(updateNewsPapperDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNewsPapperCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
