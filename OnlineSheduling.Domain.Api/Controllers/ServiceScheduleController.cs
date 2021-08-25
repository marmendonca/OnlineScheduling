using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Repositories;
using System.Collections.Generic;

namespace OnlineScheduling.Domain.Api.Controllers
{
    [Route("v1/serviceSchedules")]
    [ApiController]
    public class ServiceScheduleController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<ServiceSchedule> GetAll([FromServices]IServiceScheduleRepository repository)
        {
            return repository.GetAll();
        }
    }
}
