using System;
using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Genre;
using CinemaManagementSystem.Application.Features.Genres.Requests.Queries;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Handlers.Queries
{
    public class GetGenresRequestHandler : IRequestHandler<GetGenresRequest, List<GenreDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetGenresRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<GenreDTO>> Handle(GetGenresRequest request, CancellationToken cancellationToken)
        {
            var genres = await _unitOfWork.GenreRepository.GetAllAsync();
            return _mapper.Map<List<GenreDTO>>(genres);
        }
    }
}

