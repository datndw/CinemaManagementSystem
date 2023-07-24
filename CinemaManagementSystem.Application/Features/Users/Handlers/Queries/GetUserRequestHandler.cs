using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.User;
using CinemaManagementSystem.Application.Exceptions;
using CinemaManagementSystem.Application.Features.Users.Requests.Queries;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Handlers.Queries
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserDTO> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetDetailAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }
            return _mapper.Map<UserDTO>(user);
        }
    }
}