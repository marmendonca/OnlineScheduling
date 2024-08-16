using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Create;
using OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Update;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/professional-services")]
[ApiController]
public class ProfessionalServiceController : BaseController
{
    public ProfessionalServiceController(IMediator mediator) : base(mediator)
    { }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProfessionalServiceCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateProfessionalServiceCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);

        return Ok();
    }
}