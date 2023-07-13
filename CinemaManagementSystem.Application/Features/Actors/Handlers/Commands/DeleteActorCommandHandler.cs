using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Actors.Requests.Commands;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Actors.Handlers.Commands
{
    public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteActorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _unitOfWork.ActorRepository.GetAsync(request.Id);
            await _unitOfWork.ActorRepository.DeleteAsync(actor);
            await _unitOfWork.Save();
            return true;
        }
    }
}