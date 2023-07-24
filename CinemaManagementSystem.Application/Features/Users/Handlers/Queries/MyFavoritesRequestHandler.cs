using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Common;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Features.Users.Requests.Queries;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Handlers.Queries
{
    public class MyFavoritesRequestHandler : IRequestHandler<MyFavoritesRequest, List<MovieDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MyFavoritesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MovieDTO>> Handle(MyFavoritesRequest request, CancellationToken cancellationToken)
        {
            var movs = await _unitOfWork.UserRepository.FavoritesAsync(request.Id);
            return _mapper.Map<List<MovieDTO>>(movs);
        }
    }
}

