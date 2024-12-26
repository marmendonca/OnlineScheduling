using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Application.Commands.v1.Charges.CheckPayment;
using OnlineScheduling.Application.Commands.v1.Charges.Create;

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
    
    [HttpPost("{id}/check-payment")]
    public async Task<IActionResult> CheckPaymentAsync([FromRoute] int id)
    {
        var response = await _mediator.Send(new CheckPaymentCommand(id));

        return Ok(response);
    }
}