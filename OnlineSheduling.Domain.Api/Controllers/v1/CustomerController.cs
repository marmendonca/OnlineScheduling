﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineScheduling.Domain.Command.Commands.v1.Customer.Create;
using OnlineScheduling.Domain.Command.Commands.v1.Customer.Update;
using OnlineScheduling.Domain.Query.Queries.v1.Customer.GetById;
using System.Threading.Tasks;

namespace OnlineScheduling.Api.Controllers.v1
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetCustomerByIdQuery(id));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCustomerCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
