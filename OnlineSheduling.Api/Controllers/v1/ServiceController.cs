using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.Service.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Service.Update;
using OnlineScheduling.Domain.Query.Queries.v1.Services.GetById;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/services")]
[ApiController]
public class ServiceController : BaseController
{
    public ServiceController(IMediator mediator) : base(mediator)
    { }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetServiceByIdQuery(id));

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateServiceCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateServiceCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);

        return Ok();
    }
}