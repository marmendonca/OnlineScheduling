using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Schedules.Update;
using OnlineScheduling.Domain.Query.Queries.v1.Schedules.GetById;
using System.Threading.Tasks;
using OnlineScheduling.Domain.Query.Queries.v1.Schedules.Find;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/schedules")]
[ApiController]
public class ScheduleController : BaseController
{
    public ScheduleController(IMediator mediator) : base(mediator)
    { }
    
    [HttpGet]
    public async Task<IActionResult> FindAsync()
    {
        var response = await _mediator.Send(new FindScheduleQuery());

        return Ok(response);
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateScheduleCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);

        return Ok();
    }
}