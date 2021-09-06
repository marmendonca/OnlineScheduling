using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Handlers;
using OnlineScheduling.Domain.Commands;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Repositories;
using OnlineScheduling.Domain.Commands.Contracts;
using System.Collections.Generic;

namespace OnlineScheduling.Domain.Api.Controllers
{
    [Route("v1/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Schedule> GetSchedulesByPhone([FromServices]IScheduleRepository repository, string phone)
        {
            var schedules = repository.GetSchedulesByPhone(phone);

            return schedules;
        }

        [HttpGet]
        [Route("")]
        public Schedule GetById(long id, [FromServices]IScheduleRepository scheduleRepository)
        {
            return scheduleRepository.GetById(id);
        }

        [HttpPost]
        [Route("")]
        public IGenericCommandResult Post([FromBody]CreateScheduleCommand command, [FromServices]ScheduleHandler handler)
        {
            return handler.Handle(command);
        }

        [HttpPut]
        [Route("")]
        public IGenericCommandResult Put([FromBody]UpdateScheduleCommand command, [FromServices]ScheduleHandler handler)
        {
            return handler.Handle(command);
        }

        [HttpDelete]
        [Route("")]
        public IGenericCommandResult Delete([FromBody]DeleteScheduleCommand command, [FromServices]ScheduleHandler handler)
        {
            return handler.Handle(command);
        }
    }
}
