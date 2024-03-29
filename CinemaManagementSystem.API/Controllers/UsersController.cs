﻿using CinemaManagementSystem.Application.DTOs.Common;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.DTOs.User;
using CinemaManagementSystem.Application.Features.Users.Requests.Commands;
using CinemaManagementSystem.Application.Features.Users.Requests.Queries;
using CinemaManagementSystem.Application.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
	{
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var users = await _mediator.Send(new GetUsersRequest());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(Guid id)
        {
            var user = await _mediator.Send(new GetUserRequest { Id = id });
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateUserDTO createUserDTO)
        {
            var command = new CreateUserCommand { CreateUserDTO = createUserDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] UpdateUserDTO updateUserDTO)
        {
            var command = new UpdateUserCommand { Id = updateUserDTO.Id, UpdateUserDTO = updateUserDTO };
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
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("AddToFavorites")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<bool>> Post([FromBody] AddFavoritesDTO addFavoritesDTO)
        {
            var command = new AddToFavoritesCommand { UserId = addFavoritesDTO.UserId, MovieId = addFavoritesDTO.MovieId };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("RemoveFromFavorites")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<bool>> Post([FromBody] RemoveFavoritesDTO removeFavoritesDTO)
        {
            var command = new RemoveFromFavoritesCommand { UserId = removeFavoritesDTO.UserId, MovieId = removeFavoritesDTO.MovieId };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("MyFavorites")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<List<MovieDTO>>> MyFavorites([FromBody] Guid id)
        {
            var favs = await _mediator.Send(new MyFavoritesRequest { Id = id});
            return Ok(favs);
        }

        [HttpPost("QRPayment")]
        [Authorize(Roles = "User")]
        public Task<ActionResult<string>> Post([FromBody] PaymentInfoDTO paymentInfoDTO)
        {
            return null;
        }
    }
}