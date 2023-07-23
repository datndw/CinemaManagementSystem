using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Users.Requests.Commands;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Handlers.Commands
{
    public class AddToFavouritesCommandHandler : IRequestHandler<AddToFavoritesCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddToFavouritesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(AddToFavoritesCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.UserRepository.AddToFavorites(request.UserId, request.MovieId);
            await _unitOfWork.Save();
            return true;
        }
    }
}

