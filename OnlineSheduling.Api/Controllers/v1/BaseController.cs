using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineScheduling.Api.Controllers.v1;

public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;
        
    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}