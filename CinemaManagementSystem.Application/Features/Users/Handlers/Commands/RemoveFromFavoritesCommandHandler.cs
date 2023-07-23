using System;
using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Users.Requests.Commands;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Handlers.Commands
{
    public class RemoveFromFavouritesCommandHandler : IRequestHandler<RemoveFromFavoritesCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RemoveFromFavouritesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(RemoveFromFavoritesCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.UserRepository.RemoveFromFavorites(request.UserId, request.MovieId);
            await _unitOfWork.Save();
            return false;
        }
    }
}

