using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.Charges.Create;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/charges")]
[ApiController]
public class ChargeController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateChargeCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }
}