using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zabgc.Application.ScheduleType.Commands;
using Zabgc.Application.ScheduleType.Queries.GetScheduleTypeList;
using Zabgc.WebApi.Models.ScheduleType;

namespace Zabgc.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ScheduleTypeController : BaseController
    {
        private readonly IMapper _mapper;

        public ScheduleTypeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ScheduleTypeListVm>> Get()
        {
            var query = new GetScheduleTypeListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateScheduleTypeDto createScheduleTypeDto)
        {
            var command = _mapper.Map<CreateScheduleTypeCommand>(createScheduleTypeDto);
            var scheduleTypeId = await Mediator.Send(command);

            return Ok(scheduleTypeId);
        }
    }
}
