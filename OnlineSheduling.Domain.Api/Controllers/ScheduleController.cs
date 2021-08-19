using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Handlers;
using OnlineScheduling.Domain.Commands;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Repositories;

namespace OnlineScheduling.Domain.Api.Controllers
{
    [Route("v1/shedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public Schedule GetById(long id, [FromServices]IScheduleRepository scheduleRepository)
        {
            return scheduleRepository.GetById(id);
        }

        [HttpPost]
        [Route("")]
        public GenericCommandResult Post([FromBody]CreateScheduleCommand command, [FromServices]ScheduleHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("")]
        public GenericCommandResult Put([FromBody]UpdateScheduleCommand command, [FromServices]ScheduleHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpDelete]
        [Route("")]
        public GenericCommandResult Delete([FromBody]DeleteScheduleCommand command, [FromServices]ScheduleHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
