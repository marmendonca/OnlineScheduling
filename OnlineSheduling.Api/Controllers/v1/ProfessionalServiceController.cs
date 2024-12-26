using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Application.Commands.v1.ProfessionalServices.Create;
using OnlineScheduling.Application.Commands.v1.ProfessionalServices.Update;
using OnlineScheduling.Application.Queries.v1.ProfessionalServices.GetByProfessional;
using OnlineScheduling.Application.Queries.v1.ProfessionalServices.GetByService;

namespace OnlineScheduling.Api.Controllers.v1;

[Route("api/v1/professional-services")]
[ApiController]
public class ProfessionalServiceController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet("services/{professionalId}")]
    public async Task<IActionResult> GetServicesByProfessionalAsync([FromRoute] int professionalId)
    {
        var response = await _mediator.Send(new GetServicesByProfessionalQuery(professionalId));

        return Ok(response);
    }
    
    [HttpGet("professionals/{serviceId}")]
    public async Task<IActionResult> GetProfessionalsByServiceAsync([FromRoute] int serviceId)
    {
        var response = await _mediator.Send(new GetProfessionalsByServiceQuery(serviceId));

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