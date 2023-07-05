using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Commands
{
    public class DeleteMovieCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
