using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Handlers;
using OnlineSheduling.Domain.Commands;

namespace OnlineScheduling.Domain.Api.Controllers
{
    [Route("v1/shedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult Post([FromBody]CreateScheduleCommand command, [FromServices]ScheduleHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
