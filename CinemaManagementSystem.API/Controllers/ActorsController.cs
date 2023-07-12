using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController
	{
        private readonly IMediator _mediator;
        public ActorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}

