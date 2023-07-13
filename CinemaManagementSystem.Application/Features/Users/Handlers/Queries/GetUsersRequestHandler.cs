using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.User;
using CinemaManagementSystem.Application.Features.Users.Requests.Queries;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Handlers.Queries
{
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, List<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetUsersRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<UserDTO>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}