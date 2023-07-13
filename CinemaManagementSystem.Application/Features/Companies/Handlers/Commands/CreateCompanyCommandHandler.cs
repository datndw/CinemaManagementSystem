using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Company.Validators;
using CinemaManagementSystem.Application.Features.Companies.Requests.Commands;
using CinemaManagementSystem.Application.Responses.Company;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Companies.Handlers.Commands
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCompanyCommandResponse();
            var validator = new ICompanyDTOValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.CreateCompanyDTO);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            var company = _mapper.Map<Company>(request.CreateCompanyDTO);
            company = await _unitOfWork.CompanyRepository.AddAsync(company);
            await _unitOfWork.Save();
            response.IsSuccess = true;
            response.Message = "Creation Successful";
            response.Id = company.Id;
            response.CreateCompanyDTO = request.CreateCompanyDTO;
            return response;

        }
    }
}