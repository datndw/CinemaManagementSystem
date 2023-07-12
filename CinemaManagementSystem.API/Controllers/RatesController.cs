using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController
	{
        private readonly IMediator _mediator;
        public RatesController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}

