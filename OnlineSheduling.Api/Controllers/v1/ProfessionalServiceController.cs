using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Create;
using OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Update;
using OnlineScheduling.Domain.Query.Queries.v1.ProfessionalServices.GetByProfessional;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/professional-services")]
[ApiController]
public class ProfessionalServiceController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet("{professionalId}")]
    public async Task<IActionResult> GetServicesByProfessionalAsync([FromRoute] int professionalId)
    {
        var response = await _mediator.Send(new GetServicesByProfessionalQuery(professionalId));

        return Ok(response);
    }
    
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