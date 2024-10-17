using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.AvailableTimes.Create;
using OnlineScheduling.Domain.Query.Queries.v1.AvailableTimes.GetByProfessional;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/available-times")]
[ApiController]
public sealed class AvailableTimeController : BaseController
{
    public AvailableTimeController(IMediator mediator) : base(mediator)
    { }
        
    [HttpGet("professional")]
    public async Task<IActionResult> GetByProfessionalAsync([FromQuery] GetAvailableTimesByProfessionalQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAvailableTimeCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}