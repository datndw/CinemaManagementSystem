using System;
using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Actors.Requests.Commands;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Responses.Actor;
using CinemaManagementSystem.Application.Responses.Movie;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Actors.Handlers.Commands
{
    public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, UpdateActorCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateActorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateActorCommandResponse> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateActorCommandResponse();
            var actor = await _unitOfWork.ActorRepository.GetAsync(request.Id);
            if (request.UpdateActorDTO != null)
            {
                _mapper.Map(request.UpdateActorDTO, actor);
                await _unitOfWork.ActorRepository.UpdateAsync(actor);
                await _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Update Successful";
                response.Id = actor.Id;
                response.UpdateActorDTO = request.UpdateActorDTO;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Update Failed";
                response.Errors = new List<string> { "Actor to be updated can't not be null" };
            }
            return response;
        }
    }
}

