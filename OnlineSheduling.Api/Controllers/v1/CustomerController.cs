using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.Customer.CreateOrUpdate;
using OnlineScheduling.Domain.Query.Queries.v1.Customer.GetById;
using System.Threading.Tasks;
using OnlineScheduling.Domain.Query.Queries.v1.Customer.Find;
using OnlineScheduling.Domain.Query.Queries.v1.Customer.GetByPhone;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/customers")]
[ApiController]
public class CustomerController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetCustomerByIdQuery(id));

        return Ok(response);
    }
    
    [HttpGet("phone/{phone}")]
    public async Task<IActionResult> GetByPhoneAsync([FromRoute] string phone)
    {
        var response = await _mediator.Send(new GetCustomerByPhoneQuery(phone));

        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> FindAsync([FromQuery] FindCustomerQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdateAsync([FromBody] CreateOrUpdateCustomerCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}