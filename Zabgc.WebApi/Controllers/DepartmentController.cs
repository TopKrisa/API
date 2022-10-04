using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zabgc.Application.Department.Commands.CreateDepartment;
using Zabgc.Application.Department.Commands.DeleteDepartment;
using Zabgc.Application.Department.Commands.UpdateDepartment;
using Zabgc.Application.Department.Queries.GetDepartmentDetails;
using Zabgc.Application.Department.Queries.GetDepartmentList;
using Zabgc.WebApi.Models.Department;

namespace Zabgc.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DepartmentController : BaseController
    {
        private readonly IMapper _mapper;

        public DepartmentController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<DepartmentsListVm>> GetAll()
        {
            var query = new GetDepartmentsListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDetailsVm>> Get(Guid id)
        {
            var query = new GetDepartmentDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            var command = _mapper.Map<CreateDepartmentCommand>(createDepartmentDto);
            var departmentId = await Mediator.Send(command);

            return Ok(departmentId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentDto updateDepartmentDto)
        {
            var command = _mapper.Map<UpdateDepartmentCommand>(updateDepartmentDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDepartmentCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
