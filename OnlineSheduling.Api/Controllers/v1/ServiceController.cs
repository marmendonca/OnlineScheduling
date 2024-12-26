using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Application.Commands.v1.Service.Create;
using OnlineScheduling.Application.Commands.v1.Service.Update;
using OnlineScheduling.Application.Queries.v1.Services.Find;
using OnlineScheduling.Application.Queries.v1.Services.GetById;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/services")]
[ApiController]
public class ServiceController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> FindAsync([FromQuery] FindServiceQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(response);
    }
    
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