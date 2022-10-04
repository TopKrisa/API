using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zabgc.Application.News.Commands.CreateNews;
using Zabgc.Application.News.Commands.UpdateNews;
using Zabgc.Application.News.DeleteNews;
using Zabgc.Application.News.Queries.GetNewsList;
using Zabgc.Application.News.Queries.GetNoteDetails;
using Zabgc.WebApi.Models.News;

namespace Zabgc.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NewsController : BaseController
    {
        private readonly IMapper _mapper;
        public NewsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<NewsListVm>> GetAll()
        {
            var query = new GetNewsListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDetailsVm>> Get(Guid id)
        {
            var query = new GetNewsDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNewsDto createNewsDto)
        {
            var command = _mapper.Map<CreateNewsCommand>(createNewsDto);
            var newsId = await Mediator.Send(command);

            return Ok(newsId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNewsDto updateNewsDto)
        {
            var command = _mapper.Map<UpdateNewsCommand>(updateNewsDto);
            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNewsCommand()
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
