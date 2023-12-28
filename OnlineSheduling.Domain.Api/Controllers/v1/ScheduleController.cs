using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Repositories.v1;
using System.Collections.Generic;

namespace OnlineScheduling.Api.Controllers.v1
{
    [Route("v1/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<int> GetSchedulesByPhone([FromServices] IScheduleRepository repository, string phone)
        {
            //var schedules = repository.GetSchedulesByPhone(phone);

            //return schedules;

            return null;
        }

        //[HttpGet]
        //[Route("")]
        //public Schedule GetById(long id, [FromServices]IScheduleRepository scheduleRepository)
        //{
        //    return scheduleRepository.GetById(id);
        //}

        //[HttpPost]
        //[Route("")]
        //public IGenericCommandResult Post([FromBody]CreateScheduleCommand command, [FromServices]ScheduleHandler handler)
        //{
        //    return handler.Handle(command);
        //}

        //[HttpPut]
        //[Route("")]
        //public IGenericCommandResult Put([FromBody]UpdateScheduleCommand command, [FromServices]ScheduleHandler handler)
        //{
        //    return handler.Handle(command);
        //}

        //[HttpDelete]
        //[Route("")]
        //public IGenericCommandResult Delete([FromBody]DeleteScheduleCommand command, [FromServices]ScheduleHandler handler)
        //{
        //    return handler.Handle(command);
        //}
    }
}
