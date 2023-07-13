using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Rate;
using CinemaManagementSystem.Application.Exceptions;
using CinemaManagementSystem.Application.Features.Rates.Requests.Queries;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Rates.Handlers.Queries
{
    public class GetRateRequestHandler : IRequestHandler<GetRateRequest, RateDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetRateRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<RateDTO> Handle(GetRateRequest request, CancellationToken cancellationToken)
        {
            var rate = await _unitOfWork.RateRepository.GetAsync(request.Id);
            if (rate == null)
            {
                throw new NotFoundException(nameof(Rate), request.Id);
            }
            return _mapper.Map<RateDTO>(rate);
        }
    }
}