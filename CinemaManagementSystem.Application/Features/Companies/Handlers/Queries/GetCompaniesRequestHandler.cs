using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Company;
using CinemaManagementSystem.Application.Features.Companies.Requests.Queries;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Companies.Handlers.Queries
{
    public class GetCompaniesRequestHandler : IRequestHandler<GetCompaniesRequest, List<CompanyDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCompaniesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<CompanyDTO>> Handle(GetCompaniesRequest request, CancellationToken cancellationToken)
        {
            var actors = await _unitOfWork.CompanyRepository.GetAllAsync();
            return _mapper.Map<List<CompanyDTO>>(actors);
        }
    }
}

