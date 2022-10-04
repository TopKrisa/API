using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zabgc.Application.Page.Commands.CreatePage;
using Zabgc.Application.Page.Commands.DeletePage;
using Zabgc.Application.Page.Commands.UpdatePage;
using Zabgc.Application.Page.Queries.GetPageDetails;
using Zabgc.Application.Page.Queries.GetPageList;
using Zabgc.WebApi.Models.Page;

namespace Zabgc.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PageController : BaseController
    {
        private readonly IMapper _mapper;

        public PageController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PageListVm>> GetAll()
        {
            var query = new GetPageListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PageDetailsVm>> Get(Guid id)
        {
            var query = new GetPageDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePageDto createPageDto)
        {
            var command = _mapper.Map<CreatePageCommand>(createPageDto);
            var departmentId = await Mediator.Send(command);

            return Ok(departmentId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePageDto updatePagetDto)
        {
            var command = _mapper.Map<UpdatePageCommand>(updatePagetDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePageCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
