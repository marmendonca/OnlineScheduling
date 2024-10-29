using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.Professionals.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Professionals.Update;
using OnlineScheduling.Domain.Query.Queries.v1.Professional.Find;
using OnlineScheduling.Domain.Query.Queries.v1.Professional.GetById;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/professionals")]
[ApiController]
public class ProfessionalController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(GetProfessionalByIdQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> FindAsync([FromQuery] FindProfessionalQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(response);
    }
    
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