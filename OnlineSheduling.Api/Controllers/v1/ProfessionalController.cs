using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.Professionals.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Professionals.Update;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/professionals")]
[ApiController]
public class ProfessionalController : BaseController
{
    public ProfessionalController(IMediator mediator) : base(mediator)
    { }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProfessionalCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateProfessionalCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);

        return Ok();
    }
}