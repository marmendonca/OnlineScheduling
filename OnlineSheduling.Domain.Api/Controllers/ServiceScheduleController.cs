using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Commands;
using OnlineScheduling.Domain.Entities;

namespace OnlineSheduling.Domain.Api.Controllers
{
    [Route("v1/serviceSchedules")]
    [ApiController]
    public class ServiceScheduleController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult Post([FromBody]ServiceSchedule serviceSchedule)
        {
            return null;
        }
    }
}
