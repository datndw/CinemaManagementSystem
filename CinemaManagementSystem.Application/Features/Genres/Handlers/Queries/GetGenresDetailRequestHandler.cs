using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Genre;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Exceptions;
using CinemaManagementSystem.Application.Features.Genres.Requests.Queries;
using CinemaManagementSystem.Application.Features.Movies.Requests.Queries;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Handlers.Queries
{
    public class GetGenresDetailRequestHandler : IRequestHandler<GetGenresDetailRequest, List<GenreDetailDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetGenresDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GenreDetailDTO>> Handle(GetGenresDetailRequest request, CancellationToken cancellationToken)
        {
            var genres = await _unitOfWork.GenreRepository.GetGenresDetailAsync();
            return _mapper.Map<List<GenreDetailDTO>>(genres);
        }
    }
}

