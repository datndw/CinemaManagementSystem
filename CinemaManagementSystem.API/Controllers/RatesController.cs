using CinemaManagementSystem.Application.DTOs.Rate;
using CinemaManagementSystem.Application.Features.Rates.Requests.Commands;
using CinemaManagementSystem.Application.Features.Rates.Requests.Queries;
using CinemaManagementSystem.Application.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
	{
        private readonly IMediator _mediator;
        public RatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<RateDTO>>> Get()
        {
            var rates = await _mediator.Send(new GetRatesRequest());
            return Ok(rates);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RateDTO>> Get(Guid id)
        {
            var rate = await _mediator.Send(new GetRateRequest { Id = id });
            return Ok(rate);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateRateDTO createRateDTO)
        {
            var command = new CreateRateCommand { CreateRateDTO = createRateDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] UpdateRateDTO updateRateDTO)
        {
            var command = new UpdateRateCommand { Id = updateRateDTO.Id, UpdateRateDTO = updateRateDTO };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteRateCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}