using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zabgc.Application.PageCategory.Commands;
using Zabgc.Application.PageCategory.Queries.GetPageCategoryList;
using Zabgc.WebApi.Models.PageCategory;

namespace Zabgc.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PageCategoryController : BaseController
    {
        private readonly IMapper _mapper;
        public PageCategoryController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PageCategoryListVm>> Get()
        {
            var query = new GetPageCategoryListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePageCategoryDto createNewsCategoryDto)
        {
            var command = _mapper.Map<CreatePageCategoryCommand>(createNewsCategoryDto);
            var pageCategoryId = await Mediator.Send(command);

            return Ok(pageCategoryId);
        }
    }
}
