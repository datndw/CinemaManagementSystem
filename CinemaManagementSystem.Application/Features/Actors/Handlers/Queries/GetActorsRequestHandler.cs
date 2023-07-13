using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Actor;
using CinemaManagementSystem.Application.Features.Actors.Requests.Queries;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Actors.Handlers.Queries
{
    public class GetActorsRequestHandler : IRequestHandler<GetActorsRequest, List<ActorDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetActorsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<ActorDTO>> Handle(GetActorsRequest request, CancellationToken cancellationToken)
        {
            var actors = await _unitOfWork.ActorRepository.GetAllAsync();
            return _mapper.Map<List<ActorDTO>>(actors);
        }
    }
}