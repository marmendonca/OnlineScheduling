using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineScheduling.Api.Controllers.v1;

public abstract class BaseController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;
}