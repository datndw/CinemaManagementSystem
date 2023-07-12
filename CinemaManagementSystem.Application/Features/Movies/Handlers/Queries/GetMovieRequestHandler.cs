using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Exceptions;
using CinemaManagementSystem.Application.Features.Movies.Requests.Queries;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Queries
{
    public class GetMovieRequestHandler : IRequestHandler<GetMovieRequest, MovieDTO>
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;
        public GetMovieRequestHandler(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<MovieDTO> Handle(GetMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _repository.GetAsync(request.Id);
            if (movie == null)
            {
                throw new NotFoundException(nameof(Movie), request.Id);
            }
            return _mapper.Map<MovieDTO>(movie);
        }
    }
}