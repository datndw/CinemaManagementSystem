using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Actor.Validators;
using CinemaManagementSystem.Application.Features.Actors.Requests.Commands;
using CinemaManagementSystem.Application.Responses.Actor;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Actors.Handlers.Commands
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, CreateActorCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateActorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateActorCommandResponse> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateActorCommandResponse();
            var validator = new IActorDTOValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.CreateActorDTO);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            var actor = _mapper.Map<Actor>(request.CreateActorDTO);
            actor = await _unitOfWork.ActorRepository.AddAsync(actor);
            await _unitOfWork.Save();
            response.IsSuccess = true;
            response.Message = "Creation Successful";
            response.Id = actor.Id;
            response.CreateActorDTO = request.CreateActorDTO;
            return response;

        }
    }
}