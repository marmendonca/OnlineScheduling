using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OnlineScheduling.Application.Commands.v1.Schedules.Create;
using OnlineScheduling.Application.Commands.v1.Schedules.Update;
using OnlineScheduling.Application.Queries.v1.Schedules.Find;
using OnlineScheduling.Application.Queries.v1.Schedules.GetById;
namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/schedules")]
[ApiController]
public class ScheduleController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> FindAsync([FromQuery] FindScheduleQuery query)
    {
        var response = await _mediator.Send(query);

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
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateScheduleCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);

        return Ok();
    }
}