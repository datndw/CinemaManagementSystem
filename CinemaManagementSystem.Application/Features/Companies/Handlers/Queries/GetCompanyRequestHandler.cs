using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Company;
using CinemaManagementSystem.Application.Exceptions;
using CinemaManagementSystem.Application.Features.Companies.Requests.Queries;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Companies.Handlers.Queries
{
    public class GetCompanyRequestHandler : IRequestHandler<GetCompanyRequest, CompanyDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCompanyRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CompanyDTO> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyRepository.GetAsync(request.Id);
            if (company == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }
            return _mapper.Map<CompanyDTO>(company);
        }
    }
}