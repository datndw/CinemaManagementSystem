using AutoMapper;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Commands
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;
        public UpdateMovieCommandHandler(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _repository.GetAsync(request.Id);
            if (request.MovieDTO != null)
            {
                _mapper.Map(request.MovieDTO, movie);
                await _repository.UpdateAsync(movie);
            }
            else if (request.ChangeMovieImageUrlDTO != null)
            {
                await _repository.ChangeImageUrl(movie, request.ChangeMovieImageUrlDTO.ImageUrl);
            }
            return Unit.Value;

        }
    }
}
