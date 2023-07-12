using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController
	{
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}

