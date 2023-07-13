using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.User.Validators;
using CinemaManagementSystem.Application.Features.Users.Requests.Commands;
using CinemaManagementSystem.Application.Responses.User;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateUserCommandResponse();
            var validator = new IUserDTOValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.CreateUserDTO);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            var user = _mapper.Map<User>(request.CreateUserDTO);
            user = await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.Save();
            response.IsSuccess = true;
            response.Message = "Creation Successful";
            response.Id = user.Id;
            response.CreateUserDTO = request.CreateUserDTO;
            return response;

        }
    }
}