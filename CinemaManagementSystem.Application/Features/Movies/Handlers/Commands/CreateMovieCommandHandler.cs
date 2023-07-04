using AutoMapper;
using CinemaManagementSystem.Application.DTOs.Movie.Validators;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Persistance.Contracts;
using CinemaManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Guid>
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;
        public CreateMovieCommandHandler(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new IMovieDTOValidator(_repository);
            var validationResult = await validator.ValidateAsync(request.CreateMovieDTO);
            if (!validationResult.IsValid) {
                throw new Exception();
            }
            var movie = _mapper.Map<Movie>(request.MovieDTO);
            movie = await _repository.AddAsync(movie);
            return movie.Id;

        }
    }
}
