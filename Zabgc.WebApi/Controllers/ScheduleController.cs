using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zabgc.Application.Schedule.Commands.CreateShedule;
using Zabgc.Application.Schedule.Commands.DeleteSchedule;
using Zabgc.Application.Schedule.Commands.UpdateSchedule;
using Zabgc.Application.Schedule.Queries.GetScheduleList;
using Zabgc.WebApi.Models.Schedule;

namespace Zabgc.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ScheduleController : BaseController
    {
        private readonly IMapper _mapper;
        public ScheduleController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ScheduleListVm>> Get()
        {
            var query = new GetScheduleListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateScheduleDto createScheduleDto)
        {
            var command = _mapper.Map<CreateScheduleCommand>(createScheduleDto);
            var scheduleId = await Mediator.Send(command);

            return Ok(scheduleId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateScheduleDto updateScheduleDto)
        {
            var command = _mapper.Map<UpdateScheduleCommand>(updateScheduleDto);
            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteScheduleCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
