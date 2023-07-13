using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Rate;
using CinemaManagementSystem.Application.Features.Rates.Requests.Queries;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Rates.Handlers.Queries
{
    public class GetRatesRequestHandler : IRequestHandler<GetRatesRequest, List<RateDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetRatesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<RateDTO>> Handle(GetRatesRequest request, CancellationToken cancellationToken)
        {
            var rates = await _unitOfWork.RateRepository.GetAllAsync();
            return _mapper.Map<List<RateDTO>>(rates);
        }
    }
}