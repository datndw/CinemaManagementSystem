using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Genre;
using CinemaManagementSystem.Application.Exceptions;
using CinemaManagementSystem.Application.Features.Genres.Requests.Queries;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Handlers.Queries
{
    public class GetGenreRequestHandler : IRequestHandler<GetGenreRequest, GenreDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetGenreRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GenreDTO> Handle(GetGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = await _unitOfWork.GenreRepository.GetAsync(request.Id);
            if (genre == null)
            {
                throw new NotFoundException(nameof(Genre), request.Id);
            }
            return _mapper.Map<GenreDTO>(genre);
        }
    }
}