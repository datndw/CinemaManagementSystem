using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Features.Movies.Requests.Queries;
using CinemaManagementSystem.Application.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieRateDTO>>> Get()
        {
            var movies = await _mediator.Send(new GetMoviesRequest());
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> Get(Guid id)
        {
            var movie = await _mediator.Send(new GetMovieRequest { Id = id});
            return Ok(movie);
        }

        [HttpGet("Details/{id}")]
        public async Task<ActionResult<MovieDetailDTO>> GetDetails(Guid id)
        {
            var movie = await _mediator.Send(new GetMovieDetailRequest { Id = id });
            return Ok(movie);
        }

        [HttpGet("ByGenre/{id}")]
        public async Task<ActionResult<MovieDetailDTO>> GetByGenre(Guid id)
        {
            var movie = await _mediator.Send(new GetMoviesByGenreRequest { Id = id });
            return Ok(movie);
        }

        [HttpGet("ByCompany/{id}")]
        public async Task<ActionResult<MovieDetailDTO>> GetByCompany(Guid id)
        {
            var movie = await _mediator.Send(new GetMoviesByCompanyRequest { Id = id });
            return Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMovieDTO createMovieDTO)
        {
            var command = new CreateMovieCommand { CreateMovieDTO = createMovieDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] UpdateMovieDTO updateMovieDTO)
        {
            var command = new UpdateMovieCommand { Id =updateMovieDTO.Id, UpdateMovieDTO = updateMovieDTO };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteMovieCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
