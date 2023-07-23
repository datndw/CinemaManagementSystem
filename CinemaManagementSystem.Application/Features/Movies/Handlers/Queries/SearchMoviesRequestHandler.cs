using System;
using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Features.Movies.Requests.Queries;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Queries
{
    public class SearchMoviesRequestHandler : IRequestHandler<SearchMoviesRequest, List<MovieDetailDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SearchMoviesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<MovieDetailDTO>> Handle(SearchMoviesRequest request, CancellationToken cancellationToken)
        {
            var movies = await _unitOfWork.MovieRepository.SearchMovies(request.Keyword);
            return _mapper.Map<List<MovieDetailDTO>>(movies);
        }
    }
}

