﻿using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Features.Movies.Requests.Queries;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Queries
{
    public class GetMoviesRequestHandler : IRequestHandler<GetMoviesRequest, List<MovieDTO>>
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;
        public GetMoviesRequestHandler(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<List<MovieDTO>> Handle(GetMoviesRequest request, CancellationToken cancellationToken)
        {
            var movies = await _repository.GetAllAsync();
            return _mapper.Map<List<MovieDTO>>(movies);
        }
    }
}