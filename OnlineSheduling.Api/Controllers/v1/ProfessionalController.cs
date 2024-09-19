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
public class ProfessionalController : BaseController
{
    public ProfessionalController(IMediator mediator) : base(mediator)
    { }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(GetProfessionalByIdQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> FindAsync()
    {
        var response = await _mediator.Send(new FindProfessionalQuery());

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