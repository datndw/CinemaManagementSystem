﻿using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Commands
{
    public class DeleteMovieCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}