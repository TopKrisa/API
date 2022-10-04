using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zabgc.Application.Questions.Commands.CreateQuestion;
using Zabgc.Application.Questions.Commands.DeleteQuestion;
using Zabgc.Application.Questions.Commands.UpdateQuestion;
using Zabgc.Application.Questions.Queries.GetQuestionList;
using Zabgc.WebApi.Models.Question;

namespace Zabgc.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class QuestionController : BaseController
    {
        private readonly IMapper _mapper;
        public QuestionController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<QuestionListVm>> Get()
        {
            var query = new GetQuestionListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateQuestionDto createQuestionController)
        {
            var command = _mapper.Map<CreateQuestionCommand>(createQuestionController);
            var questionId = await Mediator.Send(command);

            return Ok(questionId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateQuestionDto updateQuestionDto)
        {
            var command = _mapper.Map<UpdateQuestionCommand>(updateQuestionDto);
            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteQuestionCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
