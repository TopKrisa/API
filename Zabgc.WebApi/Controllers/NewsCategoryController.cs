using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zabgc.Application.NewsCategory.Commands.CreateNewsCategory;
using Zabgc.Application.NewsCategory.Queries.GetNewsCategoryList;
using Zabgc.WebApi.Models.NewsCategory;

namespace Zabgc.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NewsCategoryController : BaseController
    {
        private readonly IMapper _mapper;
        public NewsCategoryController(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<NewsCategoryListVm>> Get()
        {
            var query = new GetNewsCategoryQuery();
            var newsCategoryVm = await Mediator.Send(query);

            return Ok(newsCategoryVm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNewsCategoryDto createNewsCategoryDto)
        {
            var command = _mapper.Map<CreateNewsCategoryCommand>(createNewsCategoryDto);
            var newsCategoryId = await Mediator.Send(command);

            return Ok(newsCategoryId);
        }

    }
}
