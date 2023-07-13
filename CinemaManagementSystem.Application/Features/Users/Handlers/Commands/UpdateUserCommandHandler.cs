using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Users.Requests.Commands;
using CinemaManagementSystem.Application.Responses.User;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserCommandResponse();
            var user = await _unitOfWork.UserRepository.GetAsync(request.Id);
            if (request.UpdateUserDTO != null)
            {
                _mapper.Map(request.UpdateUserDTO, user);
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Update Successful";
                response.Id = user.Id;
                response.UpdateUserDTO = request.UpdateUserDTO;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Update Failed";
                response.Errors = new List<string> { "User to be updated can't not be null" };
            }
            return response;
        }
    }
}