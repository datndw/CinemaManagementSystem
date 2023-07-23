using System;
using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Features.Movies.Requests.Queries;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Queries
{
    public class GetMoviesByGenreRequestHandler : IRequestHandler<GetMoviesByGenreRequest, List<MovieRateDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetMoviesByGenreRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<MovieRateDTO>> Handle(GetMoviesByGenreRequest request, CancellationToken cancellationToken)
        {
            var movies = await _unitOfWork.MovieRepository.GetMoviesByGenre(request.Id);
            return _mapper.Map<List<MovieRateDTO>>(movies);
        }
    }
}

