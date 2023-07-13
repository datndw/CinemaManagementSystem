using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Companies.Requests.Commands;
using CinemaManagementSystem.Application.Responses.Company;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Companies.Handlers.Commands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, UpdateCompanyCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateCompanyCommandResponse();
            var company = await _unitOfWork.CompanyRepository.GetAsync(request.Id);
            if (request.UpdateCompanyDTO != null)
            {
                _mapper.Map(request.UpdateCompanyDTO, company);
                await _unitOfWork.CompanyRepository.UpdateAsync(company);
                await _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Update Successful";
                response.Id = company.Id;
                response.UpdateCompanyDTO = request.UpdateCompanyDTO;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Update Failed";
                response.Errors = new List<string> { "Company to be updated can't not be null" };
            }
            return response;
        }
    }
}