using System;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Features.Movies.Requests.Queries;
using CinemaManagementSystem.Application.Responses.Common;
using System.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CinemaManagementSystem.Application.DTOs.Company;
using CinemaManagementSystem.Application.Features.Companies.Requests.Queries;
using CinemaManagementSystem.Application.Features.Companies.Requests.Commands;

namespace CinemaManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyDTO>>> Get()
        {
            var companies = await _mediator.Send(new GetMoviesRequest());
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> Get(Guid id)
        {
            var company = await _mediator.Send(new GetCompanyRequest { Id = id });
            return Ok(company);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCompanyDTO createCompanyDTO)
        {
            var command = new CreateCompanyCommand { CreateCompanyDTO = createCompanyDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] UpdateCompanyDTO updateCompanyDTO)
        {
            var command = new UpdateCompanyCommand { Id = updateCompanyDTO.Id, UpdateCompanyDTO = updateCompanyDTO };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteCompanyCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

