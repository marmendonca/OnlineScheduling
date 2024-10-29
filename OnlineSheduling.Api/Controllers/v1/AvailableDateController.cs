using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.AvailableDates.ChangeActive;
using OnlineScheduling.Domain.Command.Commands.v1.AvailableDates.Create;
using OnlineScheduling.Domain.Query.Queries.v1.AvailableDates.Find;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/available-dates")]
[ApiController]
public sealed class AvailableDateController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> FindAsync([FromQuery] FindAvailableDatesQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAvailableDateCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> ChangeActiveAsync([FromRoute] int id, [FromBody] ChangeActiveAvailableDateCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);

        return Ok();
    }
}