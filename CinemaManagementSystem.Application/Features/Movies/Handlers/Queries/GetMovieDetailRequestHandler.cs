using System;
using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Exceptions;
using CinemaManagementSystem.Application.Features.Movies.Requests.Queries;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Queries
{
    public class GetMovieDetailRequestHandler : IRequestHandler<GetMovieDetailRequest, MovieDetailDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetMovieDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<MovieDetailDTO> Handle(GetMovieDetailRequest request, CancellationToken cancellationToken)
        {
            var movie = await _unitOfWork.MovieRepository.GetMovieDetailAsync(request.Id);
            if (movie == null)
            {
                throw new NotFoundException(nameof(Movie), request.Id);
            }
            return _mapper.Map<MovieDetailDTO>(movie);
        }
    }
}

