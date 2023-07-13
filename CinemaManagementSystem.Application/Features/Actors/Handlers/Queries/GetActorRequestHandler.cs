using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Actor;
using CinemaManagementSystem.Application.Exceptions;
using CinemaManagementSystem.Application.Features.Actors.Requests.Queries;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Actors.Handlers.Queries
{
    public class GetActorRequestHandler : IRequestHandler<GetActorRequest, ActorDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetActorRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ActorDTO> Handle(GetActorRequest request, CancellationToken cancellationToken)
        {
            var actor = await _unitOfWork.ActorRepository.GetAsync(request.Id);
            if (actor == null)
            {
                throw new NotFoundException(nameof(Actor), request.Id);
            }
            return _mapper.Map<ActorDTO>(actor);
        }
    }
}