using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.Customer.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Customer.Update;
using OnlineScheduling.Domain.Query.Queries.v1.Customer.GetById;
using System.Threading.Tasks;
using OnlineScheduling.Domain.Query.Queries.v1.Customer.Find;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/customers")]
[ApiController]
public class CustomerController : BaseController
{
    public CustomerController(IMediator mediator) : base(mediator)
    { }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetCustomerByIdQuery(id));

        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> FindAsync()
    {
        var response = await _mediator.Send(new FindCustomerQuery());

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCustomerCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);

        return Ok();
    }
}