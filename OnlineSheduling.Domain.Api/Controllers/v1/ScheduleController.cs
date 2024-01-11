using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Schedules.Update;
using OnlineScheduling.Domain.Query.Queries.v1.Schedules.GetById;
using System.Threading.Tasks;

namespace OnlineScheduling.Api.Controllers.v1
{
    [Route("api/v1/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetScheduleByIdQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateScheduleCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateScheduleCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
